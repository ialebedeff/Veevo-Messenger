using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Veevo.BLL.Interfaces;
using Veevo.BLL.Models.Responses.Updates;

namespace Veevo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UpdateController : ControllerBase
    {
        private readonly IUpdateService _updateService;
        private readonly IUserService _userService;
        public UpdateController(
            IUpdateService updateService,
            IUserService userService)
        { 
            _updateService = updateService;
            _userService = userService;
        }

        /// <summary>
        /// Получить список обновлений/уведомлений, и пометить его как уже не нужный
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("GetUpdates")]
        public IActionResult GetUpdates()
        {
            var user = _userService.GetUserByUsername(User.Identity?.Name);
            
            if (user == null)
                return BadRequest();

            var updates = _updateService.GetUpdates(user.Id);
                          _updateService.MarkAsUpdated(updates);
                          _updateService.SaveChanges();

            return Ok(new UpdateResponseModel() { Updates = updates });
        }
    }
}
