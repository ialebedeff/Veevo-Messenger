using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veevo.BLL.Models.Database;

namespace Veevo.BLL.Models.Responses.Models
{
    public class CreateAccountResponseModel : BaseResponseModel
    {
        [JsonConstructor]
        public CreateAccountResponseModel() { }
        [JsonConstructor]
        public CreateAccountResponseModel(ModelStateDictionary modelState) : base(modelState) { }
        /// <summary>
        /// Данные от созданного пользователем аккаунта
        /// </summary>
        public UserDatabaseModel? User { get; set; }
    }
}
