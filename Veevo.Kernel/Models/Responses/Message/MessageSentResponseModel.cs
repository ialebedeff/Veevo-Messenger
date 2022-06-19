using Veevo.Kernel.Models.Entities;
using Veevo.Kernel.Models.Responses;

namespace Veevo.Kernel.Models.Responses.Message
{
    public class MessageSentResponseModel : BaseResponseModel
    {

        public MessageSentResponseModel() : base() { }
        //public MessageSentResponseModel(HttpResponseMessage httpResponseMessage) : base(httpResponseMessage) { }
        /// <summary>
        /// Объект отправленного сообщения
        /// </summary>
        public MessageModel? Message { get; set; }
        
    }
}
