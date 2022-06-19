using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veevo.BLL.Contexts;
using Veevo.BLL.Enums;
using Veevo.BLL.Interfaces;
using Veevo.BLL.Models.Database;

namespace Veevo.BLL.Services
{
    public class UpdateService : IUpdateService
    {
        private DatabaseContext _context;
        public UpdateService(DatabaseContext context) => _context = context; 
        public UpdateDatabaseModel CreateUpdate(int userId, UpdateType updateType, UpdateEntity updateEntity)
        {
            var entry = _context.Updates.Add(new UpdateDatabaseModel()
            {
                Entity = updateEntity,
                IsUpdated = false,
                UserId = userId,
                Type = ((int)updateType)
            });

            return entry.Entity;
        }

        public IEnumerable<UpdateDatabaseModel> GetUpdates(int userId)
        {
            return _context.Updates.Where(x => x.UserId == userId && !x.IsUpdated);
        }

        public void MarkAsUpdated(IEnumerable<UpdateDatabaseModel> updates)
        {
            var listUpdates = updates.ToList();

            listUpdates.ForEach(x => _context.Updates.Find(x.Id).IsUpdated = true);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
