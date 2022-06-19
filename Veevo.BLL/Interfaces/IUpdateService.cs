using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veevo.BLL.Enums;
using Veevo.BLL.Models.Database;

namespace Veevo.BLL.Interfaces
{
    public interface IUpdateService
    {
        /// <summary>
        /// Пометить обновления как 'Обновленные' / 'IsUpdated'
        /// </summary>
        /// <param name="updates"></param>
        public void MarkAsUpdated(IEnumerable<UpdateDatabaseModel> updates);
        /// <summary>
        /// Получить список обновлений ('Новые сообщения', 'Новые диалоги')
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<UpdateDatabaseModel> GetUpdates(int userId);
        /// <summary>
        /// Создать оповещение/обновление
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="updateType"></param>
        /// <param name="updateEntity"></param>
        /// <returns></returns>
        public UpdateDatabaseModel CreateUpdate(int userId, UpdateType updateType, UpdateEntity updateEntity);
        /// <summary>
        /// Сохранить данные
        /// </summary>
        public void SaveChanges();
    }
}
