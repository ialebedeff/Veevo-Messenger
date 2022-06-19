using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veevo.Kernel.Models.Requests
{
    public class SendMessageTextRequestModel
    {
        /// <summary>
        /// Id пользователя, которому отправляется сообщение
        /// </summary>
        public int ToUserId { get; set; }
        /// <summary>
        /// Текст сообщения. Максимальная длина сообщения 800 символов.
        /// </summary>
        public string Text { get; set; } = null!;
    }
}
