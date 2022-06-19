using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veevo.DSK.ViewModels
{
    internal class ProfilePropertiesViewModel : BaseViewModel
    {
        private string _initials = null!;
        private string _email = null!;
        private string _username = null!;
        public string Initials
        {
            get { return _initials; }
            set
            {
                _initials = value;
                OnPropertyChanged("Initials");
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }
    }
}
