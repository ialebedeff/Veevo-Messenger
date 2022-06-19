using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veevo.BLL.Models.Responses.Models;

namespace Veevo.BLL.Models.Responses
{
    public class MessageDelitedResponseModel : BaseResponseModel
    {
        /// <summary>
        /// Id удаленного сообщения
        /// </summary>
        public int MessageId { get; set; }
    }
}
