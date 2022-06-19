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
        public void MarkAsUpdated(IEnumerable<UpdateDatabaseModel> updates);
        public IEnumerable<UpdateDatabaseModel> GetUpdates(int userId);
        public UpdateDatabaseModel CreateUpdate(int userId, UpdateType updateType, UpdateEntity updateEntity);
        public void SaveChanges();
    }
}
