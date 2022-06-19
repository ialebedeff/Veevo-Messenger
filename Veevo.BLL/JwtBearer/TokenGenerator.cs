using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Veevo.BLL.Models.Database;

namespace Veevo.BLL.JwtBearer
{
    internal class TokenGenerator
    {
        public string Generate(UserDatabaseModel userDatabaseModel)
        {
            var identity = GetIdentity(userDatabaseModel);

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                    issuer: ApplicationOptions.ISSUER,
                    audience: ApplicationOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(ApplicationOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(ApplicationOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
        private ClaimsIdentity GetIdentity(UserDatabaseModel userDatabaseModel)
        {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, userDatabaseModel.Email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, userDatabaseModel.Role)
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                    claims, 
                    "Token",
                    ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);

                return claimsIdentity;
        }
    }
}
