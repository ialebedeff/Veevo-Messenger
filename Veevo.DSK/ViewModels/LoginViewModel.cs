using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Veevo.DSK.Pages;
using Veevo.DSK.ViewModels.Commands;
using Veevo.DSK.ViewModels.Properties;
using Veevo.Kernel.API;
using Veevo.Kernel.Models.Requests;

namespace Veevo.DSK.ViewModels
{
    public class LoginViewModel : LoginPropertiesViewModel
    {
        public LoginViewModel()
        {
            CreateAccountCommand = new RelayCommand(OpenRegistrationPage);
            LoginCommand = new RelayCommand(o => LoginAsync(o as PasswordBox));
        }
        
        /// <summary>
        /// Команда открывает страницу регистрации нового аккаунта
        /// </summary>
        public ICommand CreateAccountCommand { get; set; }
        /// <summary>
        /// Команда выполняет авторизацию пользователя
        /// </summary>
        public ICommand LoginCommand { get; set; }
        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="passwordBox"></param>
        public async void LoginAsync(PasswordBox? passwordBox)
        {
            if (passwordBox == null)
                return;

            IsLoginEnabled = !IsLoginEnabled;
            Password = ((PasswordBox)passwordBox).Password;

            var response = await VeevoAPI.LoginAsync(new LoginRequestModel(Email, Password));

            if (response.IsSuccess)
            {
                await VeevoAPI.GetMeAsync();

                AppNavigation.AddPage(typeof(MessengerPage), new MessengerPage()); 
                AppNavigation.ShowPage(typeof(MessengerPage));
            }
            else
                Status = response?.ErrorMessage ?? "Не верный логин или пароль";

            IsLoginEnabled = !IsLoginEnabled;
        }
        /// <summary>
        /// Открыть страницу регистрации
        /// </summary>
        /// <param name="o"></param>
        public void OpenRegistrationPage(object o) => AppNavigation.ShowPage(typeof(RegistrationPage));

    }
}
