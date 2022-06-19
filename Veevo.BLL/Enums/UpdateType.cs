using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veevo.BLL.Enums
{
    public enum UpdateType
    {
        /// <summary>
        /// Собеседник написал и отправил сообщение
        /// </summary>
        NewMessage = 0,
        /// <summary>
        /// Собеседник удалил сообщение
        /// </summary>
        DeleteMessage = 1,
        /// <summary>
        /// Собеседник пишет сообщение
        /// </summary>
        Typing = 2,
    }
}
