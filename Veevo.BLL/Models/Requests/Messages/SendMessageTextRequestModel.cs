using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veevo.BLL.Models.Requests.Messages
{
    public class SendMessageTextRequestModel
    {
        [Required(ErrorMessage = "Dialog ID is empty.")]
        public int ToUserId { get; set; }
        [MaxLength(512, ErrorMessage = "The maximum message length is 512 characters.")]
        [Required(ErrorMessage = "Message text is empty.")]
        public string Text { get; set; }
    }
}
