using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veevo.BLL.Models.Database;
using Veevo.BLL.Models.Responses.Models;

namespace Veevo.BLL.Models.Responses
{
    public class MessageEditedResponseModel : BaseResponseModel
    {
        /// <summary>
        /// Новые измененный объект сообщения
        /// </summary>
        public MessageDatabaseModel? Message { get; set; }
    }
}
