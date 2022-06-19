using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veevo.BLL.JwtBearer
{
    public class ApplicationOptions
    {
        public TokenValidationParameters TokenValidationParameters { 
            get { 
                return new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = ISSUER,
                    ValidateAudience = true,
                    ValidAudience = AUDIENCE,
                    ValidateLifetime = true,
                    IssuerSigningKey = GetSymmetricSecurityKey(),
                    ValidateIssuerSigningKey = true,
                };  
            }
        }

        public const string ISSUER = "VEEVO.API"; 
        public const string AUDIENCE = "VEEVO.CLIENT"; 
        public const string KEY = "EE03E590AF0347A70DAAC32C1182E8A716FCABF412937C6AF1F30B206C5380E2227D3A2890AD3BB0D04587EE9455A78FD152A2D399772FF6B58E8AD5C5DE731A";   // ключ для шифрации
        public const int LIFETIME = 1 /*минута*/ * 60 /*час*/ * 24 /*сутки*/ * 7 /*неделя*/; 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
