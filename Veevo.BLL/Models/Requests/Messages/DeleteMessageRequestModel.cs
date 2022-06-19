using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veevo.BLL.Models.Requests.Messages
{
    public class DeleteMessageRequestModel
    {
        [Required(ErrorMessage = "Message ID is empty.")]
        public int MessageId { get; set; }
    }
}
