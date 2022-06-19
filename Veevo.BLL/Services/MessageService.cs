using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veevo.BLL.Contexts;
using Veevo.BLL.Interfaces;
using Veevo.BLL.Models.Database;
using Veevo.BLL.Models.Requests.Messages;

namespace Veevo.BLL.Services
{
    public class MessageService : IMessageService
    {
        private readonly DatabaseContext _context;
        public MessageService(DatabaseContext databaseContext) => _context = databaseContext;

        public MessageDatabaseModel CreateTextMessage(SendMessageTextRequestModel textMessage, int fromId)
        {
            var entry = _context.Messages.Add(new MessageDatabaseModel()
            {
                CreateDate = DateTime.UtcNow,
                FromId = fromId,
                Text = textMessage.Text,
                IsDeleted = false,
                IsEdited = false,
                IsRead = false,
                ToUserId = textMessage.ToUserId
            });

            return entry.Entity;
        }
        public IEnumerable<MessageDatabaseModel> GetMessages(int userId, GetMessagesRequestModel messagesRequest)
        {
            return _context.Messages.Where(x => (x.FromId == userId && x.ToUserId == messagesRequest.UserId) || (x.FromId == messagesRequest.UserId && x.ToUserId == userId));
        }
        public int DeleteMessage(DeleteMessageRequestModel deleteMessage)
        {
            throw new NotImplementedException();
        }

        public MessageDatabaseModel EditMessage(EditMessageRequestModel editMessage)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
