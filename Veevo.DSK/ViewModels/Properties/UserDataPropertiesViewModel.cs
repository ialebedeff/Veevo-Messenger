using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veevo.Kernel.Models.Responses.Account;

namespace Veevo.DSK.ViewModels.Properties
{
    internal class UserDataPropertiesViewModel : BaseViewModel
    {
        public UserDataPropertiesViewModel(UserResponseModel userModel)
        {
            Username = userModel.User.Username;
            LastSeen = userModel.User.LastSeen.ToUniversalTime().ToString("hh:mm");
        }
        private string _lastSeen = null!;
        private string _username = null!;
        public string LastSeen
        { 
            get => _lastSeen;
            set {
                _lastSeen = value;
                OnPropertyChanged("LastSeen");
            }
        }
        public string Username
        {
            get => _username;
            set {
                _username = value;
                OnPropertyChanged("Username");
            }
        }
    }
}
