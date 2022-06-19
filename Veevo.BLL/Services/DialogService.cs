using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veevo.BLL.Contexts;
using Veevo.BLL.Interfaces;
using Veevo.BLL.Models.Database;

namespace Veevo.BLL.Services
{
    public class DialogService : IDialogService
    {
        private DatabaseContext _context;
        public DialogService(DatabaseContext databaseContext) => _context = databaseContext;
        public DialogDatabaseModel CreateDialog(IEnumerable<int> userIds)
        {
            var entry = _context.Dialogs.Add(new DialogDatabaseModel() { CreatedDate = DateTime.UtcNow, Users = userIds.ToList(), IsDeleted = false });

            return entry.Entity;
        }

        public void DeleteDialog(int dialogId)
        {

        }

        public DialogDatabaseModel? GetDialog(IEnumerable<int> userIds)
        {
            return _context.Dialogs.FirstOrDefault(x => x.Users == userIds);
        }


        public bool DialogExists(IEnumerable<int> userIds)
        {
            var users = _context.Dialogs.Select(x => x.Users).ToList();

            foreach (var u in users)
                if (new HashSet<int>(u.ToList()).SetEquals(userIds.ToList()))
                    return true;

            return false;
        }

        public IEnumerable<DialogDatabaseModel> GetDialogs(int userId)
        {
            return _context.Dialogs.Where(x => x.Users.Contains(userId));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public DialogDatabaseModel? GetDialog(int dialogId)
        {
            var dialog = _context.Dialogs.Find(dialogId);

            return _context.Dialogs.Find(dialogId);
        }
    }
}
