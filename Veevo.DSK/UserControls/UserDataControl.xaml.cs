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

namespace Veevo.DSK.UserControls
{
    /// <summary>
    /// Логика взаимодействия для UserDataControl.xaml
    /// </summary>
    public partial class UserDataControl : UserControl
    {
        public UserDataControl()
        {
            InitializeComponent();
        }
        public UserDataControl(UserResponseModel userModel)
        {
            InitializeComponent();

            this.DataContext = new UserDataControlViewModel(userModel);
            this.User = userModel;
        }
        public UserResponseModel User { get; set; } = null!;
    }
}
