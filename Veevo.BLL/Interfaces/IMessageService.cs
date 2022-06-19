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
        /// <summary>
        /// Получить список сообщений
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="messagesRequest"></param>
        /// <returns></returns>
        public IEnumerable<MessageDatabaseModel> GetMessages(int userId, GetMessagesRequestModel messagesRequest);
        /// <summary>
        /// Создать текстовое сообщение
        /// </summary>
        /// <param name="textMessage"></param>
        /// <param name="fromId"></param>
        /// <returns></returns>
        public MessageDatabaseModel CreateTextMessage(SendMessageTextRequestModel textMessage, int fromId);
        /// <summary>
        /// Удалить сообщение
        /// </summary>
        /// <param name="deleteMessage"></param>
        /// <returns></returns>
        public int DeleteMessage(DeleteMessageRequestModel deleteMessage);
        /// <summary>
        /// Редактировать сообщение
        /// </summary>
        /// <param name="editMessage"></param>
        /// <returns></returns>
        public MessageDatabaseModel EditMessage(EditMessageRequestModel editMessage);
        /// <summary>
        /// Сохранить данные
        /// </summary>
        public void SaveChanges();
    }
}
