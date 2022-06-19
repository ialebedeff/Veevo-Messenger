using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veevo.BLL.Models.Database;

namespace Veevo.BLL.Interfaces
{
    public interface IDialogService
    {
        /// <summary>
        /// Создать диалог между пользователями
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns></returns>
        public DialogDatabaseModel CreateDialog(IEnumerable<int> userIds);
        /// <summary>
        /// Получить диалоги пользователя
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<DialogDatabaseModel>? GetDialogs(int userId);
        /// <summary>
        /// Получить диалог по Id
        /// </summary>
        /// <param name="dialogId"></param>
        /// <returns></returns>
        public DialogDatabaseModel? GetDialog(int dialogId);
        /// <summary>
        /// Получить диалоги с указанными пользователя
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns></returns>
        public DialogDatabaseModel? GetDialog(IEnumerable<int> userIds);
        /// <summary>
        /// Удалить диалог по Id
        /// </summary>
        /// <param name="dialogId"></param>
        public void DeleteDialog(int dialogId);
        /// <summary>
        /// Проверка на существование диалога между пользователями
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns></returns>
        public bool DialogExists(IEnumerable<int> userIds);
        /// <summary>
        /// Сохранение данных
        /// </summary>
        public void SaveChanges();
    }
}
