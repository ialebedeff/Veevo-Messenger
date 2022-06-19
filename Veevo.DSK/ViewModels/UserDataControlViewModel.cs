using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veevo.DSK.ViewModels.Properties;
using Veevo.Kernel.Models.Responses.Account;

namespace Veevo.DSK.ViewModels
{
    internal class UserDataControlViewModel : UserDataPropertiesViewModel
    {
        public UserDataControlViewModel(UserResponseModel userModel) : base(userModel) { }
    }
}
