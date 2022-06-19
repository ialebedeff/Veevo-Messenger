using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Veevo.DSK.UserControls;
using Veevo.Kernel.Models.Entities;

namespace Veevo.DSK.ViewModels.Properties
{
    internal class DialogPropertiesViewModel : BaseViewModel
    {
        private ObservableCollection<MessageModel> _messagesCollection = null!;
        private ObservableCollection<MessageItem> _messagesItemCollection = null!;
        private Visibility _epmtyDialogVisibility;
        private string _messageText = null!;
        private string _username = null!;
        private string _lastSeen = null!;
        private int _userId;
        public ObservableCollection<MessageItem> MessagesItemCollection
        {
            get { return _messagesItemCollection; }
            set
            {
                _messagesItemCollection = value;
                OnPropertyChanged("MessagesItemCollection");
            }
        }
        public ObservableCollection<MessageModel> MessagesCollection {
            get => _messagesCollection;
            set {
                _messagesCollection = value;
                OnPropertyChanged("MessagesCollection");
            }
        }
        public Visibility EmptyDialogVisibility
        {
            get { return _epmtyDialogVisibility; }
            set
            {
                _epmtyDialogVisibility = value;
                OnPropertyChanged("EmptyDialogVisibility");
            }
        }
        public string MessageText
        {
            get { return _messageText; }
            set
            {
                _messageText = value;
                OnPropertyChanged("MessageText");
            }
        }
        public string Username
        {
            get => _username;
            set {
                _username = value;
                OnPropertyChanged("Username");
            }
        }
        public string LastSeen {
            get => _lastSeen;
            set {
                _lastSeen = value != null ? "last seen:" + value : "last seen recently";
                OnPropertyChanged("LastSeen");
            }
        }
        public int UserId {
            get => _userId;
            set {
                _userId = value;
                OnPropertyChanged("UserId");
            }
        }
    }
}
