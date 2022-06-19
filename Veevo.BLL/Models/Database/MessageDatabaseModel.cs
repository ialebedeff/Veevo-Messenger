using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Veevo.BLL.Models.Database
{
    public class MessageDatabaseModel
    {
        /// <summary>
        /// Id сообщения
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Дата создания сообщения
        /// </summary>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// Сообщение редактировано
        /// </summary>
        public bool IsEdited { get; set; }
        /// <summary>
        /// Сообщение удалено
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// Сообщение прочитано
        /// </summary>
        public bool IsRead { get; set; }
        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string? Text { get; set; }
        /// <summary>
        /// Id автора сообщения
        /// </summary>
        public int FromId { get; set; }
        /// <summary>
        /// Id пользователя, которому адресовано сообщение
        /// </summary>
        public int ToUserId { get; set; }
    }
}
