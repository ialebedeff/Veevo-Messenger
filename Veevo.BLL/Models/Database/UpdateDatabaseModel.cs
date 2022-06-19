using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Veevo.BLL.Enums;

namespace Veevo.BLL.Models.Database
{
    public class UpdateEntity
    { 
        public int Id { get; set; }
        /// <summary>
        /// Тело апдейта, может быть равно null;
        /// </summary>
        public MessageDatabaseModel? Message { get; set; }
        public UserDatabaseModel? User { get; set; }
    }
    public class UpdateDatabaseModel
    {
        /// <summary>
        /// Id update`a
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Id пользователя, для которого требуется получить обновление
        /// </summary>
        [JsonIgnore]
        public int UserId { get; set; }
        /// <summary>
        /// Тип обновления: 'Новое сообщение', 'Сообщение удалено', 'Кто-то печатает'
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// Сущность обновления: 'Сообщение', 'Пользователь и т.д'
        /// </summary>
        public UpdateEntity? Entity { get; set; }
        /// <summary>
        /// Получено ли обновление пользователем.
        /// </summary>
        [JsonIgnore]
        public bool IsUpdated { get; set; }
    }
}
