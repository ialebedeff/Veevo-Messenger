using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veevo.BLL.Models.Database;
using Veevo.BLL.Models.Requests.Messages;

namespace Veevo.BLL.Interfaces
{
    public interface IMessageService
    {
        public IEnumerable<MessageDatabaseModel> GetMessages(int userId, GetMessagesRequestModel messagesRequest);
        public MessageDatabaseModel CreateTextMessage(SendMessageTextRequestModel textMessage, int fromId);
        public int DeleteMessage(DeleteMessageRequestModel deleteMessage);
        public MessageDatabaseModel EditMessage(EditMessageRequestModel editMessage);
        public void SaveChanges();
    }
}
