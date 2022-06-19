using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veevo.Kernel.Models.Responses
{
    public class CreateAccountResponseModel : BaseResponseModel 
    {
        public CreateAccountResponseModel() : base() { }
        //public CreateAccountResponseModel(HttpResponseMessage httpResponseMessage) : base(httpResponseMessage) { }
        public UserModel? User { get; set; }
    }
}
