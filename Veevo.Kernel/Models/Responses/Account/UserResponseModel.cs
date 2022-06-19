using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veevo.Kernel.Models.Responses.Account
{
    public class UserResponseModel : BaseResponseModel
    {
        public UserResponseModel() : base() { }
        //public UserResponseModel(HttpResponseMessage httpResponseMessage) : base(httpResponseMessage) { }
        public UserModel User { get; set; } = null!;
    }
}
