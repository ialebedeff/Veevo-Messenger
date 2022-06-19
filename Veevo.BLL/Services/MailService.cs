using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Net.Mail;
using Veevo.BLL.Contexts;
using Veevo.BLL.Interfaces;

namespace Veevo.BLL.Services
{
    public class MailService : IMailService
    {
        private DatabaseContext _context;
        public MailService(DatabaseContext context)
        {
            _context = context;
        }
        public GmailService GetGmailService()
        {
            using (var stream =
                       new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    new[] { GmailService.Scope.GmailSend },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;

                return new GmailService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Veevo.API"
                });
            }
        }
        public async Task<bool> SendConfirmationEmailAsync(string email, string code)
        {
            var pattern = File.ReadAllText("Files/Patterns/ConfirmationEmailPattern.html").Replace("#URL", $"https://localhost:7218/user/verify?code={code}");

            var mail = new MailMessage
            {
                Subject = "COMPLETE REGISTRATION",
                Body = pattern,
                IsBodyHtml = true,
            };

            mail.To.Add(new MailAddress(email));

            var mimeMessage = MimeKit.MimeMessage.CreateFromMailMessage(mail);
            var message = new Message() { Raw = Base64UrlEncode(mimeMessage.ToString()) };

            try
            {
                await GetGmailService().Users.Messages.Send(message, email).ExecuteAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        private static string Base64UrlEncode(string input)
        {
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            // Special "url-safe" base64 encode.
            return Convert.ToBase64String(inputBytes)
              .Replace('+', '-')
              .Replace('/', '_')
              .Replace("=", "");
        }
    }
}

