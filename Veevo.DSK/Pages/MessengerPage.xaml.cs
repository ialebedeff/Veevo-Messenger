using System.Windows;
using System.Windows.Controls;
using Veevo.DSK.Extensions;
using Veevo.DSK.UserControls;
using Veevo.DSK.ViewModels;

namespace Veevo.DSK.Pages
{
    /// <summary>
    /// Логика взаимодействия для MessengerPage.xaml
    /// </summary>
    public partial class MessengerPage : Page
    {
        public MessengerPage()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UserListBox.SelectedItem != null)
                AppNavigation.OpenDialog(((UserDataControl)UserListBox.SelectedItem).User);
        }
    }
}
