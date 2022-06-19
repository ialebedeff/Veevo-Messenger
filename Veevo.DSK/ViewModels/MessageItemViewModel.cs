using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Veevo.Kernel.API;
using Veevo.Kernel.Models.Entities;
using Veevo.Kernel.Models.Requests;
using Veevo.Kernel.Models.Responses.Message;

namespace Veevo.DSK.ViewModels
{
    internal class MessageItemViewModel : BaseViewModel
    {
        private Visibility _messageStatusVisibility;
        private PackIconKind _messageStatus;
        public Visibility MessageStatusVisibility
        {
            get => _messageStatusVisibility;
            set {
                _messageStatusVisibility = value;
                OnPropertyChanged("MessageStatusVisibility");
            }
        }
        public PackIconKind MessageStatus
        {
            get => _messageStatus;
            set { 
                _messageStatus = value;
                OnPropertyChanged("MessageStatus");
            }
        }
        private MessageModel _message = null!;
        private string? _messageText = null!;
        private HorizontalAlignment _messageAlign;
        public HorizontalAlignment MessageAlign
        {
            get => _messageAlign;
            set { 
                _messageAlign = value;
                OnPropertyChanged("MessageAlign");
            }
        }
        /// <summary>
        /// Отправлено от лица текущего пользователя
        /// </summary>
        public bool SendByMe
        {
            set {
                if (value)
                    MessageAlign = HorizontalAlignment.Right;
                else
                {
                    MessageAlign = HorizontalAlignment.Left;
                    MessageStatusVisibility = Visibility.Hidden;
                }
            }
        }
        /// <summary>
        /// Сообщение успешно отправлено
        /// </summary>
        public bool Successfully { get; set; }
        /// <summary>
        /// Время отправки сообщения в формате hh:mm
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string? MessageText
        {
            get { return _messageText; }
            set
            {
                _messageText = value;
                OnPropertyChanged("MessageText");
            }
        }
        public MessageModel Message { 
            get => _message;
            set {
                _message = value;
                CreateTime = value.CreateDate.HasValue ? value.CreateDate : DateTime.Now;
                MessageText = value.Text;
                if (!value.IsRead)
                    MessageStatus = PackIconKind.Check;
                else
                    MessageStatus = PackIconKind.CheckAll;

                OnPropertyChanged("Message");
            }
        }
        public MessageItemViewModel(MessageModel messageModel)
        {
            Message = messageModel;
            SendByMe = Message.SendByMe;
        }
        public MessageItemViewModel(SendMessageTextRequestModel messageModel)
        {
            MessageText = messageModel.Text;
            SendByMe = true;

            SendMessageAsync(messageModel);
        }

        /// <summary>
        /// Отправить сообщение
        /// </summary>
        public async void SendMessageAsync(SendMessageTextRequestModel sendMessageTextRequestModel)
        {
            MessageStatus = PackIconKind.ClockTimeEightOutline;

            var messageResponse = await VeevoAPI.SendTextMessageAsync(sendMessageTextRequestModel);

            if (messageResponse != null && messageResponse.IsSuccess && messageResponse.Message != null)
            {
                Message = messageResponse.Message;
            }
            else
            {
                if (string.IsNullOrEmpty(MessageText))
                {
                    MessageText = "Пустое сообщение";
                }

                MessageStatus = PackIconKind.AlertCircleOutline;
            }
        }
    }
}
