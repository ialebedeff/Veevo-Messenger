using Google.Apis.Gmail.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veevo.BLL.Interfaces
{
    public interface IMailService
    {
        /// <summary>
        /// Инициализировать или получить Google Mail Service для дальнейшей отправки электронных писем
        /// </summary>
        /// <returns></returns>
        public GmailService GetGmailService();
        /// <summary>
        /// Отправить письмо для подтверждения почтового адреса
        /// </summary>
        /// <param name="email"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<bool> SendConfirmationEmailAsync(string email, string code);
    }
}
