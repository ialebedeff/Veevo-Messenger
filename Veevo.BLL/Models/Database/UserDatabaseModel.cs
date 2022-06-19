using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Veevo.BLL.Models.Database
{
    public class UserDatabaseModel
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Роль пользователя
        /// </summary>
        public string Role { get; set; } = null!;
        /// <summary>
        /// Почтовый адрес пользователя
        /// </summary>
        public string Email { get; set; } = null!;
        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [JsonIgnore]
        public string Password { get; set; } = null!;
        /// <summary>
        /// Публичный Email адрес или нет
        /// </summary>
        public bool? IsPublicEmail { get; set; } = null!;
        /// <summary>
        /// Юзернейм пользователя
        /// </summary>
        public string Username { get; set; } = null!;
        /// <summary>
        /// Код подтвверждения аккаунта
        /// </summary>
        [JsonIgnore]
        public string ConfirmationCode { get; set; } = null!;
        /// <summary>
        /// Дата создания аккаунта
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Аккаунт активирован или нет
        /// </summary>
        public bool IsActivated { get; set; }
        /// <summary>
        /// Последний онлайн пользователя
        /// </summary>
        public DateTime? LastOnline { get; set; }
    }
}
