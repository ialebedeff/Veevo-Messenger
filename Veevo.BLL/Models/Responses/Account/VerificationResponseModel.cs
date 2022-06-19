using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veevo.BLL.Models.Responses.Models;

namespace Veevo.BLL.Models.Responses.Account
{
    public class VerificationResponseModel : BaseResponseModel
    {
        [JsonConstructor]
        public VerificationResponseModel(ModelStateDictionary modelState) : base(modelState) { }
        [JsonConstructor]
        public VerificationResponseModel() : base() { }
    }
}
