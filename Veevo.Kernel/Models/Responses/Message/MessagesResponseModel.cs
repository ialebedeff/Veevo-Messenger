using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veevo.Kernel.Models.Entities;

namespace Veevo.Kernel.Models.Responses.Message
{
    public class MessagesResponseModel : BaseResponseModel
    {
        public IEnumerable<MessageModel>? Messages { get; set; }
    }
}
