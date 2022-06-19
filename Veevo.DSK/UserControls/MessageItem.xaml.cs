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
using Veevo.Kernel.Models.Entities;
using Veevo.Kernel.Models.Requests;

namespace Veevo.DSK.UserControls
{
    /// <summary>
    /// Логика взаимодействия для MessageUserControl.xaml
    /// </summary>
    public partial class MessageItem : UserControl
    {
        public MessageItem()
        {
            InitializeComponent();
        }
        public MessageItem(MessageModel messageModel)
        {
            InitializeComponent();

            this.DataContext = new MessageItemViewModel(messageModel);
        }
        public MessageItem(SendMessageTextRequestModel sendMessageTextRequestModel)
        {
            InitializeComponent();

            this.DataContext = new MessageItemViewModel(sendMessageTextRequestModel);
        }

        private void HyperlinkRichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
