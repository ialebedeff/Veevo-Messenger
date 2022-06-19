using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veevo.Kernel.Models.Requests
{
    public class UserRequestModel
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public int? Id { get; set; }
    }
}
