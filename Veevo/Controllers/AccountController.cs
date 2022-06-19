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

        /// <summary>
        /// �������� ������������ �� ����������� Id
        /// </summary>
        /// <param name="userRequestModel"></param>
        /// <returns>���������� � ������������</returns>
        [Authorize]
        [HttpPost("GetUserById")]
        public IActionResult GetUserById(GetUserRequestModel userRequestModel)
        { 
            return Ok(new UserResponseModel() { User = _userService.GetUserById(userRequestModel.Id) });
        }
        /// <summary>
        /// ����������� �������� ������������ �� ������ �� �����
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Ok - ����, ��� ������, BadRequest - ���� ���</returns>
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

            return BadRequest(new VerificationResponseModel(ModelState) { ErrorMessage = "�� ���������� ��� �������������."});
        }
        /// <summary>
        /// ����� ��������� ��� ��������� ���������� � ���� ��� ��������������� ������������
        /// </summary>
        /// <returns></returns>
        [HttpGet("User")]
        [Authorize]
        public IActionResult GetUser()
        {
            return Ok(new UserResponseModel() { User = _userService.GetUserByEmail(User.Identity?.Name) });
        }

        /// <summary>
        /// ����� ������������ �� Username
        /// </summary>
        /// <param name="userRequestModel"></param>
        /// <returns>���� Username �����, �� ������ BadRequest � ��������� ������, � ��������� ������� Ok, � ��������, ������ ���������������� �������</returns>
        [HttpPost("GetUserByUsername")]
        public IActionResult GetUserByUsername(GetUserRequestModel userRequestModel)
        {
            if (string.IsNullOrEmpty(userRequestModel.Username))
            {
                return BadRequest(new UserResponseModel(ModelState) { ErrorMessage = "���� 'Username' �� ���������" });
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
                ModelState.AddModelError("ErrorRu", "������������ �� ������");
                ModelState.AddModelError("ErrorEn", "User not found.");

                response = new UserResponseModel(ModelState) { ErrorMessage = "������������ �� ������" };
            }

            return Ok(response);

        }

        /// <summary>
        /// �������� ������� ��������, ������������� ��� ���
        /// </summary>
        /// <param name="verificationRequestModel"></param>
        /// <returns>Ok - ���� ����� ���� ������������, BadRequest ���� - ���</returns>
        [HttpPost("CheckVerification")]
        public IActionResult WaitVerification(VerificationRequestModel verificationRequestModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(new CheckVerificationResponseModel(ModelState));

            return _userService.IsUserVerified(verificationRequestModel) ?
                Ok(new CheckVerificationResponseModel() { IsAccountVerified = true }) : 
                BadRequest(new CheckVerificationResponseModel() { IsAccountVerified = false });
        }

        /// <summary>
        /// �������� �������� � �������� ������ �� �����
        /// </summary>
        /// <param name="registrationRequestModel"></param>
        /// <returns>����� Ok, ���� ������� ��� ������ � ������ � ������������ ���� ������� ����������.</returns>
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
                    return BadRequest(new CreateAccountResponseModel(modelState: ModelState) { ErrorMessage = "�� �� ����� ��������� �� ��� Email ����� ������ � �����, ����������, ���������� ������ Email" });
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