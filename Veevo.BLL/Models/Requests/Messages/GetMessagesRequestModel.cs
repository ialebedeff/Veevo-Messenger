using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veevo.BLL.Models.Requests.Messages
{
    public class GetMessagesRequestModel
    {
        /// <summary>
        /// Id собеседника
        /// </summary>
        [Required]
        public int UserId { get; set; }
    }
}
