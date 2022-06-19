using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veevo.BLL.Models.Database;
using Veevo.BLL.Models.Responses.Models;

namespace Veevo.BLL.Models.Responses.Account
{
    public class UserResponseModel : BaseResponseModel
    {
        public UserResponseModel(ModelStateDictionary modelState) : base(modelState) { }
        public UserResponseModel() : base() { }
        public UserDatabaseModel? User { get; set; }
    }
}
