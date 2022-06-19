using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Veevo.DSK.ViewModels;
using Veevo.Kernel.Models.Responses.Account;

namespace Veevo.DSK.Pages
{
    /// <summary>
    /// Логика взаимодействия для DialogPage.xaml
    /// </summary>
    public partial class DialogPage : Page
    {
        public DialogPage()
        {
            InitializeComponent();
        }

        public DialogPage(UserResponseModel userResponseModel)
        {
            InitializeComponent();

            this.DataContext = new DialogViewModel(userResponseModel);
        }

        private void MessageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.DeadCharProcessedKey == Key.Return)
            {
                ((DialogViewModel)this.DataContext).AddNewMessageToCollection(MessageTextBox);
                ScrollViewer.ScrollToEnd();
            }
        }

        private void ItemsControl_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            ScrollViewer.ScrollToEnd();
        }

        private void ItemsControl_LayoutUpdated(object sender, EventArgs e)
        {
            ScrollViewer.ScrollToEnd();
        }
    }
}
