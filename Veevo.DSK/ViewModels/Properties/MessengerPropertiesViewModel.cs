using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using Veevo.DSK.UserControls;
using Veevo.Kernel.API;
using Veevo.Kernel.Models.Entities;
using Veevo.Kernel.Models.Requests;
using Veevo.Kernel.Models.Responses.Account;

namespace Veevo.DSK.ViewModels
{
    internal class MessengerPropertiesViewModel : BaseViewModel
    {
        public MessengerPropertiesViewModel() {
            Users = new ObservableCollection<UserDataControl>();
            _dialogs = new ObservableCollection<DialogModel>();

            GetDialogsTask = GetDialogsAsync();
        }
        private Task GetDialogsTask { get; set; }
        private ObservableCollection<DialogModel> _dialogs = null!;
        private ObservableCollection<UserDataControl> _users = null!;
        private string _search = null!;
        public string Search
        {
            get => _search;
            set {
                _search = value;

                if (!string.IsNullOrEmpty(value))
                    SearchByUsername();
                else
                    GetDialogsTask = GetDialogsAsync();

                OnPropertyChanged("Search");
            }
        }
        public ObservableCollection<UserDataControl> Users
        {
            get => _users;
            set {
                _users = value;
                OnPropertyChanged("Users");
            }
        }
        public async Task GetDialogsAsync()
        {
            Users.Clear();

            var dialogResponse = await VeevoAPI.GetDialogs();

            if (dialogResponse != null && dialogResponse.IsSuccess)
            {
                dialogResponse.Dialogs?.ForEach(async dialog => await ShowDialogItemAsync(dialog));
            }
        }
        public async void ShowSavedMessages()
        {
            var responseModel = await VeevoAPI.GetUserById(new UserRequestModel() { Id = VeevoAPI.User?.Id });

            if (responseModel.IsSuccess)
            {
                responseModel.User.Username = "Saved Messages";
                Users.Add(new UserDataControl(responseModel));
            }
        }
        public async void SearchByUsername()
        {
            if (string.IsNullOrEmpty(Search))
                return;

            var userModel = await VeevoAPI.GetUserByUsernameAsync(new UserRequestModel() { Username = Search});

            if (userModel.IsSuccess)
                ShowOnlyOneUser(userModel);
        }
        public async Task ShowDialogItemAsync(DialogModel dialogModel)
        {
            if (dialogModel.IsDeleted)
                return;

            foreach (var id in dialogModel.Users)
            {
                if (id != VeevoAPI.User?.Id)
                {
                    var responseModel = await VeevoAPI.GetUserById(new UserRequestModel() { Id = id });
                    if (responseModel.IsSuccess)
                        Users.Add(new UserDataControl(responseModel));
                }
            }
        }
        public void ShowOnlyOneUser(UserResponseModel userResponseModel)
        {
            if (userResponseModel == null)
                return;

            Users.Clear();
            Users.Add(new UserDataControl(userResponseModel));
        }
    }
}
