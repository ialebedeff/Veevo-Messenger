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
        public GmailService GetGmailService();
        public Task<bool> SendConfirmationEmailAsync(string email, string code);
    }
}
