using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Veevo.BLL.Enums;
using Veevo.BLL.Interfaces;
using Veevo.BLL.Models.Database;
using Veevo.BLL.Models.Requests.Messages;
using Veevo.BLL.Models.Responses;
using Veevo.BLL.Models.Responses.Dialogs;
using Veevo.BLL.Models.Responses.Messages;

namespace Veevo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;
        private readonly IDialogService _dialogService;
        private readonly IUpdateService _updateService;
        public MessageController(
            IMessageService messageService,
            IUserService userService,
            IDialogService dialogService,
            IUpdateService updateService)
        {
            _messageService = messageService;
            _userService = userService;
            _dialogService = dialogService;
            _updateService = updateService;
        }
        [Authorize]
        [HttpPost("GetMessages")]
        public IActionResult GetMessages(GetMessagesRequestModel messagesRequest)
        {
            if (User.Identity == null)
                return BadRequest();

            var user = _userService.GetUserByEmail(User.Identity.Name);

            if (user == null) { return BadRequest(); }

            var messages = _messageService.GetMessages(user.Id, messagesRequest);

            return Ok(new MessagesResponseModel() { Messages = messages });
        }
        [Authorize]
        [HttpPost("GetDialogs")]
        public IActionResult GetDialogs()
        {
            if (User.Identity == null || !ModelState.IsValid || User.Identity.Name == null)
                return BadRequest();

            var user = _userService.GetUserByEmail(User.Identity.Name);

            if (user == null)
                return BadRequest();


            return Ok(new GetDialogsResponseModel() { Dialogs = _dialogService.GetDialogs(user.Id) });
        }

        [Authorize]
        [HttpPost("SendMessageText")]
        public IActionResult SendMessage(SendMessageTextRequestModel textMessage)
        {
            if (User.Identity == null || !ModelState.IsValid)
                return BadRequest();

            try
            {
                var from = _userService.GetUserByEmail(User.Identity.Name);

                if (from == null)
                    return BadRequest();

                if (!_dialogService.DialogExists(new int[] { from.Id, textMessage.ToUserId })) 
                    _dialogService.CreateDialog(new int[] { from.Id, textMessage.ToUserId });

                var message = _messageService.CreateTextMessage(textMessage, from.Id);
                var update = _updateService.CreateUpdate(textMessage.ToUserId, UpdateType.NewMessage, new UpdateEntity() { Message = message });

                _messageService.SaveChanges();
                _updateService.SaveChanges();

                return Ok(new MessageSentResponseModel() { Message = message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new MessageSentResponseModel() { ErrorMessage = ex.Message });
            }
        }
    }
}
