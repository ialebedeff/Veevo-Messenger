using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Veevo.DSK.Pages;
using Veevo.Kernel.Models.Responses.Account;

namespace Veevo.DSK
{
    public static class AppNavigation
    {
        public static Dictionary<string, Page>? Pages { get; set; }
        public static Dictionary<int, Page> Dialogs { get; set; } = null!;
        public static void Initialize()
        {
            Dialogs = new Dictionary<int, Page>();
            Pages = new Dictionary<string, Page>();
            
            Pages.Add(typeof(LoginPage).Name, new LoginPage());
            Pages.Add(typeof(RegistrationPage).Name, new RegistrationPage());
        }

        public static void AddPage(Type type, Page page) => Pages?.Add(type.Name, page);
        public static void OpenDialog(UserResponseModel userResponseModel)
        {
            if (!Dialogs.ContainsKey(userResponseModel.User.Id))
                Dialogs.Add(userResponseModel.User.Id, new DialogPage(userResponseModel));

            (MainWindow?.Frame.Content as MessengerPage)?.MessengerFrame.Navigate(Dialogs[userResponseModel.User.Id]);
        }
        public static MainWindow? MainWindow { 
            get=> Application.Current.MainWindow as MainWindow;
        }
        public static void ShowPage(Type type) => MainWindow?.Frame.Navigate(Pages?[type.Name]);
        public static void RefreshCurrentPage() => MainWindow?.Frame.Refresh();
        public static object? GetCurrentContent() => MainWindow?.Frame.Content;
        public static Page? GetCurrentPage() => MainWindow?.Frame.Content as Page;
        public static object? GetCurrentPageContext() => (MainWindow?.Frame.Content as Page)?.DataContext;
        public static void TryBack()
        {
            if (MainWindow?.Frame.CanGoBack == true)
            {
                MainWindow?.Frame.GoBack();
            }
        }
    }
}
