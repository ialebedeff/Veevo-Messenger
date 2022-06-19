using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Veevo.API.Extensions;
using Veevo.BLL.Exceptions;
using Veevo.BLL.Interfaces;
using Veevo.BLL.Models.Requests;
using Veevo.BLL.Models.Responses;
using Veevo.BLL.Models.Responses.Account;
using Veevo.BLL.Models.Responses.Models;

namespace Veevo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMailService _mailService;
        private readonly IUserService _userService;
        public UserController(
            IUserService userService,
            IMailService mailService)
        {
            _userService = userService;
            _mailService = mailService;
        }
        [Authorize]
        [HttpPost("GetUserById")]
        public IActionResult GetUserById(GetUserRequestModel userRequestModel)
        { 
            return Ok(new UserResponseModel() { User = _userService.GetUserById(userRequestModel.Id) });
        }
        [HttpGet("Verify")]
        public IActionResult Verify(string code)
        {
            if (!ModelState.IsValid)
                return BadRequest(new VerificationResponseModel(ModelState));

            if (_userService.VerifyUser(code))
            {
                _userService.SaveChanges();

                return Ok(new VerificationResponseModel() );
            }

            return BadRequest(new VerificationResponseModel(ModelState) { ErrorMessage = "Не правильный код подтверждения."});
        }
        [HttpGet("User")]
        [Authorize]
        public IActionResult GetUser()
        {
            return Ok(new UserResponseModel() { User = _userService.GetUserByEmail(User.Identity?.Name) });
        }
        [HttpPost("GetUserByEmail")]
        public IActionResult GetUserByEmail()
        {
            return Ok();
        }
        //[Authorize]
        [HttpPost("GetUserByUsername")]
        public IActionResult GetUserByUsername(GetUserRequestModel userRequestModel)
        {
            if (string.IsNullOrEmpty(userRequestModel.Username))
            {
                return BadRequest(new UserResponseModel(ModelState) { ErrorMessage = "Поле 'Username' не заполнено" });
            }

            var user = _userService.GetUserByUsername(userRequestModel.Username);
            var response = new UserResponseModel();

            if (user != null)
            {
                response.User = user;

                if (response.User.IsPublicEmail == false || response.User.IsPublicEmail == null)
                    response.User.Email = string.Empty;
            }
            else
            {
                ModelState.AddModelError("ErrorRu", "Пользователь не найден");
                ModelState.AddModelError("ErrorEn", "User not found.");

                response = new UserResponseModel(ModelState) { ErrorMessage = "Пользователь не найден" };
            }

            return Ok(response);

        }
        [HttpPost("CheckVerification")]
        public IActionResult WaitVerification(VerificationRequestModel verificationRequestModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(new CheckVerificationResponseModel(ModelState));

            return _userService.IsUserVerified(verificationRequestModel) ?
                Ok(new CheckVerificationResponseModel() { IsAccountVerified = true }) : 
                BadRequest(new CheckVerificationResponseModel() { IsAccountVerified = false });
        }

        //[HttpPost("CreateAdmin")]
        //[Authorize("Admin")]
        //public IActionResult CreateAdminAccount(RegistrationRequestModel registrationRequestModel)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(new Response(modelState: ModelState));

        //    try
        //    {
        //        var user = _userService.CreateUser(registrationRequestModel, "Admin");

        //        _userService.SaveChanges();

        //        return Ok(new Response(user));
        //    }
        //    catch (EmailExistException ex)
        //    {
        //        return BadRequest(new Response(responseMessage: ex.Message));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new Response(responseMessage: ex.Message));
        //    }
        //}
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateAccount(RegistrationRequestModel registrationRequestModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(new CreateAccountResponseModel(modelState: ModelState));

            try
            {
                var user = _userService.CreateUser(registrationRequestModel, "DefaultUser");

                _userService.SaveChanges();

                if (await _mailService.SendConfirmationEmailAsync(registrationRequestModel.Email, user.ConfirmationCode) == false)
                {
                    return BadRequest(new CreateAccountResponseModel(modelState: ModelState) { ErrorMessage = "Мы не можем отправить на ваш Email адрес письмо с кодом, пожалуйста, попробуйте другой Email" });
                }

                return Ok(new CreateAccountResponseModel() { User = user });
            }
            catch (EmailExistException ex)
            {
                ModelState.AddModelError("Error", ex.Message);

                return BadRequest(new CreateAccountResponseModel(modelState: ModelState) { ErrorMessage = ex.Message });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);

                return StatusCode(500, new CreateAccountResponseModel(modelState: ModelState) { ErrorMessage = ex.Message });
            }
        }
    }
}