using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veevo.DSK.ViewModels.Properties
{
    public class LoginPropertiesViewModel : BaseViewModel
    {
        private string _status = null!;
        private string _email = null!;
        private bool _isLoginEnabled = false;
        public bool IsLoginEnabled
        {
            get => _isLoginEnabled;
            set
            {
                _isLoginEnabled = value;
                OnPropertyChanged("IsLoginEnabled");
            }
        }
        /// <summary>
        /// Статус авторизации.
        /// </summary>
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }
        /// <summary>
        /// Email пользователя для авторизации
        /// </summary>
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                IsLoginEnabled = string.IsNullOrWhiteSpace(value) ? false : true;
                OnPropertyChanged("Email");
            }
        }
        /// <summary>
        /// Пароль пользователя для авторизации
        /// </summary>
        public string Password { get; set; } = null!;
    }
}
