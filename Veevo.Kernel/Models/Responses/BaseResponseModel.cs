using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace Veevo.Kernel.Models.Responses
{
    
    public abstract class BaseResponseModel
    {
        public int Status { get; set; } = 200;
        [JsonConstructor]
        public BaseResponseModel() { }
        //public BaseResponseModel(HttpResponseMessage httpResponseMessage) => HttpResponse = httpResponseMessage;
        public HttpResponseMessage? HttpResponse { get; set; }
        public Dictionary<string, string[]>? ModelState { get; set; }
        public bool IsSuccess => (Status >= 200 && Status <= 299) && string.IsNullOrEmpty(ErrorMessage);
        public string? ErrorMessage { get; set; }
    }
}
