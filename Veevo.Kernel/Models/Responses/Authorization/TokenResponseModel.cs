using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Veevo.Kernel.Models.Responses
{
    public class TokenResponseModel : BaseResponseModel
    {
        //public TokenResponseModel(HttpResponseMessage httpResponseMessage) : base(httpResponseMessage) { }
        public string? Token { get; set; }
    }
}
