using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veevo.Kernel.Enums;

namespace Veevo.Kernel.Models.Entities
{
    public class UpdateEntity
    { 
        /// <summary>
        /// Id сущности, которое вызвало апдейт
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Пользователь
        /// </summary>
        public UserModel? User { get; set; }
        /// <summary>
        /// Сообщение
        /// </summary>
        public MessageModel? Message { get; set; }
    }
    public class UpdateModel
    {
        /// <summary>
        /// Id  обновления
        /// </summary>
        public int Id { get; set; }
        public UpdateType Type { get; set; }
        public UpdateEntity UpdateEntity { get; set; } = null!;

    }
}
