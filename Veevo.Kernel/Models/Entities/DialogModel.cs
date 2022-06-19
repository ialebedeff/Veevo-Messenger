using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veevo.Kernel.Models.Entities
{
    public class DialogModel
    {
        public int Id { get; set; }
        public List<int> Users { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
