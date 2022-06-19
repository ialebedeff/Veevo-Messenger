using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Veevo.BLL.Models.Database
{
    public class UserDatabaseModel
    {
        public int Id { get; set; }
        public string Role { get; set; } = null!;
        public string Email { get; set; } = null!;
        [JsonIgnore]
        public string Password { get; set; } = null!;
        public bool? IsPublicEmail { get; set; } = null!;
        public string Username { get; set; } = null!;
        [JsonIgnore]
        public string ConfirmationCode { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public bool IsActivated { get; set; }
        public DateTime? LastOnline { get; set; }
    }
}
