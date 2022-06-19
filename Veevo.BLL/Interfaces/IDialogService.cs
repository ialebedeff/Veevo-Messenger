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
        public DialogDatabaseModel CreateDialog(IEnumerable<int> userIds);
        public IEnumerable<DialogDatabaseModel>? GetDialogs(int userId);
        public DialogDatabaseModel? GetDialog(int dialogId);
        public DialogDatabaseModel? GetDialog(IEnumerable<int> userIds);
        public void DeleteDialog(int dialogId);
        public bool DialogExists(IEnumerable<int> userIds);
        public void SaveChanges();
    }
}
