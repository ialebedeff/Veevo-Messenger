using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veevo.BLL.Models.Database
{
    public class DialogDatabaseModel
    {
        public int Id { get; set; }
        public List<int> Users { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
