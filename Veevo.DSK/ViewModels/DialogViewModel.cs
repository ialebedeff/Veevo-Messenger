
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Veevo.DSK.UserControls;
using Veevo.DSK.ViewModels.Commands;
using Veevo.DSK.ViewModels.Properties;
using Veevo.Kernel.API;
using Veevo.Kernel.Models.Entities;
using Veevo.Kernel.Models.Responses.Account;

namespace Veevo.DSK.ViewModels
{
    internal class DialogViewModel : DialogPropertiesViewModel
    {
        public DialogViewModel(UserResponseModel userResponseModel)
        {
            NewLineCommand = new RelayCommand(AppendNewLine);
            SendMessageCommand = new RelayCommand(o => AddNewMessageToCollection(o as TextBox));
            MessagesCollection = new ObservableCollection<MessageModel>();
            MessagesItemCollection = new ObservableCollection<MessageItem>();
            MessagesCollection.CollectionChanged += MessagesCollection_CollectionChanged;
            UserId = userResponseModel.User.Id;
            Username = userResponseModel.User.Username;
            LastSeen = userResponseModel.User.LastSeen.ToShortDateString();

            GetMessagesOnLoadTask = GetMessagesAsync();
        }

        private Task GetMessagesOnLoadTask { get; set; }
        public ICommand NewLineCommand { get; set; }
        public ICommand SendMessageCommand { get; set; }

        private async Task GetMessagesAsync()
        {
            var messageResponse = await VeevoAPI.GetMessages(new Kernel.Models.Requests.GetMessagesRequestModel() { UserId = this.UserId });


            if (messageResponse != null && messageResponse.IsSuccess && messageResponse.Messages != null)
            {
                foreach (var message in messageResponse.Messages)
                {
                    message.SendByMe = message.FromId != this.UserId;
                    MessagesCollection.Add(message);
                }
            }
        }
        private void MessageCollection_CollectionChanged(object? sender,
            System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            EmptyDialogVisibility = MessagesCollection.Count == 0 ? Visibility.Visible : Visibility.Hidden;

        public void AppendNewLine(object textB)
        {
            var textBox = textB as TextBox;

            if (textBox == null)
                return;

            textBox.AppendText("\n");
            textBox.CaretIndex += 1;
        }

        public void AddNewMessageToCollection(TextBox? textBox)
        {
            if (textBox == null)
                return;

            MessageText = textBox.Text;
            MessagesItemCollection.Add(new MessageItem(new Kernel.Models.Requests.SendMessageTextRequestModel() { Text = MessageText, ToUserId = UserId }));

            textBox.Focus();
            textBox.Clear();
        }
        private void MessagesCollection_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            EmptyDialogVisibility = MessagesItemCollection.Count == 0 ? Visibility.Visible : Visibility.Hidden;

            App.Current.Dispatcher.BeginInvoke((Action)delegate ()
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    if (e.NewItems == null)
                        return;

                    foreach (var messageModel in e.NewItems)
                        MessagesItemCollection.Add(new MessageItem((MessageModel)messageModel));
                }
            });
        }
    }
}
