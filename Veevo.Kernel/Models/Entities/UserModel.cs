using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veevo.Kernel.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public string Role { get; set; } = null!;
        public DateTime LastSeen { get; set; }
    }
}
