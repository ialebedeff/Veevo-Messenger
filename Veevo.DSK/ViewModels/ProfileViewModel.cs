using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Veevo.DSK.ViewModels.Commands;
using Veevo.Kernel.API;

namespace Veevo.DSK.ViewModels
{
    internal class ProfileViewModel : ProfilePropertiesViewModel
    {
        public ProfileViewModel()
        {
            GetUserInfoCommand = new RelayCommand(GetUserInfo);
        }
        public ICommand GetUserInfoCommand { get; set; }
        public async void GetUserInfo(object o)
        {
            var response = await VeevoAPI.GetMeAsync();

            if (response != null && response.IsSuccess)
            {
              
                this.Email = response.User.Email;
                this.Username = response.User.Username;
                this.Initials = response.User.Username;
            }

            //MessageBox.Show(response.ErrorMessage);

        }
    }
}
