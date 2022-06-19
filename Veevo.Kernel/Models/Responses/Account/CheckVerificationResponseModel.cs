using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veevo.Kernel.Models.Responses.Account
{
    class CheckVerificationResponseModel : BaseResponseModel
    {
        public CheckVerificationResponseModel() : base() { }
        //public CheckVerificationResponseModel(HttpResponseMessage httpResponseMessage) : base(httpResponseMessage) { }
        public bool IsAccountVerified { get; set; }
    }
}
