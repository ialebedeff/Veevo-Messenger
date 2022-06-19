using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veevo.Kernel.Models.Responses;

namespace Veevo.Kernel.Token
{
    public static class TokenReader
    {
        private static bool IsTokenExists => File.Exists(ApplicationData.Constsants.TokenPath);
        private static bool IsDataDirectoryExists => Directory.Exists(ApplicationData.Constsants.DictionaryData);
        public static void SaveToken(TokenResponseModel? token)
        {
            if (token == null || string.IsNullOrEmpty(token.Token))
                return;

            if (!IsDataDirectoryExists)
            {
                try
                {
                    var dir = Directory.CreateDirectory(ApplicationData.Constsants.DictionaryData);
                }
                catch
                { }
            }

            if (IsDataDirectoryExists)
            {
                File.WriteAllText(ApplicationData.Constsants.TokenPath, JsonConvert.SerializeObject(token));
            }
        }
        public static string ReadToken()
        {
            if (IsDataDirectoryExists && IsTokenExists)
            {
                try
                {
                    var token = JsonConvert.DeserializeObject<TokenResponseModel>(File.ReadAllText(ApplicationData.Constsants.TokenPath));

                    return token.Token ?? string.Empty;
                }
                catch { }
            }

            return string.Empty;
        }
    }
}
