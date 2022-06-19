using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Veevo.DSK.Pages;
using Veevo.DSK.ViewModels.Commands;
using Veevo.Kernel.API;
using Veevo.Kernel.Models.Requests;
using Veevo.Kernel.Models.Responses;

namespace Veevo.DSK.ViewModels
{
    internal class RegistrationViewModel : BaseViewModel
    {
        private Visibility _loadingVisibility = Visibility.Visible;
        public Visibility LoadingVisibility
        {
            get { return _loadingVisibility; }
            set
            {
                _loadingVisibility = value;
                OnPropertyChanged("LoadingVisibility");
            }
        }
        private Visibility _controlVisibility = Visibility.Hidden;
        public Visibility ControlVisibility
        {
            get { return _controlVisibility; }
            set
            {
                _controlVisibility = value;
                OnPropertyChanged("ControlVisibility");
            }
        }
        private string _email = null!;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }
        private string _status = null!;
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }
        public string? Password { get; set; } = null!;
        public string? ConfirmPassword { get; set; } = null!;

        public async Task WaitVerification()
        {
            ControlVisibility = Visibility.Visible;

            Status = "Вам пришло письмо на почту. Подтвердите Email адрес.";

            while (!await VeevoAPI.IsAccountVerified(new VerificationRequestModel(Email)) == true)
            {
                await Task.Delay(1000);
            }

            ControlVisibility = Visibility.Hidden;
        }
        public async Task<CreateAccountResponseModel> CreateAccountAsync()
        {
            return await VeevoAPI.CreateAccountAsync(
                            new RegistrationRequestModel()
                            {
                                Email = this.Email,
                                Password = this.Password,
                                ConfirmPassword = this.ConfirmPassword,
                            }
                        );
        }
        private void ConvertPasswordBoxes(object parameter)
        {
            var pswBoxes = parameter as List<object>;

            Password = ((PasswordBox?)pswBoxes?.FirstOrDefault())?.Password;
            ConfirmPassword = ((PasswordBox?)pswBoxes?.LastOrDefault())?.Password;
        }
        
        public ICommand OnBackClick
        {
            get => new RelayCommand(o => { AppNavigation.ShowPage(typeof(LoginPage)); });
        }
        public ICommand OnRegistrationClick
        {
            get => new RelayCommand(async objects =>
            {
                ConvertPasswordBoxes(objects);

                var response = await CreateAccountAsync();

                if (response.IsSuccess == true)
                {
                    await WaitVerification();
                }
                else
                {
                   
                }

            });
        }

    }
}
