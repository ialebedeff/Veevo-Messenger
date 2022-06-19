using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veevo.BLL.JwtBearer;
using Veevo.BLL.Models.Database;
using Veevo.BLL.Models.Responses.Models;

namespace Veevo.BLL.Models.Responses.Authorization
{
    public class TokenResponseModel : BaseResponseModel
    {
        public TokenResponseModel() : base() { }
        [JsonConstructor]
        public TokenResponseModel(ModelStateDictionary modelState) : base(modelState) { }
        [JsonConstructor]
        public TokenResponseModel(UserDatabaseModel userDatabaseModel)
        {
            Token = new TokenGenerator().Generate(userDatabaseModel);
        }
        public string? Token { get; set; }
    }
}
