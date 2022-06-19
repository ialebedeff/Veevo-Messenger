using Microsoft.AspNetCore.Mvc;
using Veevo.BLL.Interfaces;
using Veevo.BLL.Models.Requests;
using Veevo.BLL.Models.Responses;
using Veevo.API.Extensions;
using Veevo.BLL.Models.Responses.Authorization;

namespace Veevo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("SignIn")]
        public IActionResult SignIn(LoginRequestModel loginRequestModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TokenResponseModel(modelState: ModelState) { ErrorMessage = ModelState.ToJson() });

            if (_userService.IsUserExist(
                email: loginRequestModel.Email,
                password: loginRequestModel.Password))
            {
                var user = _userService.GetUserByEmail(loginRequestModel.Email);
                           _userService.MakeOnline(loginRequestModel.Email);
                           _userService.SaveChanges();

                if (user?.IsActivated == false)
                {
                    ModelState.AddModelError("ErrorEn", "Email address is not confirmed");
                    ModelState.AddModelError("ErrorRu", "Вы ещё не подтвердили ваш Email. Зайдите на почту и пройдите по ссылке в письме.");

                    return BadRequest(new TokenResponseModel(modelState: ModelState) { ErrorMessage = "Вы ещё не подтвердили ваш Email. Зайдите на почту и пройдите по ссылке в письме" });
                }

                return Ok(user != null ? new TokenResponseModel(user) : new TokenResponseModel() { ErrorMessage = "Ошибка авторизации, попробуйте еще раз." });
            }
            else
            {
                ModelState.AddModelError("ErrorEn", "Incorrect email or password");
                ModelState.AddModelError("ErrorRu", "Не верный логин или пароль");
                return BadRequest(new TokenResponseModel(modelState: ModelState) { ErrorMessage = "Не верный логин или пароль" });
            }
        }
    }
}
