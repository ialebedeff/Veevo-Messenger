using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Veevo.BLL.Models.Database
{
    public class MessageDatabaseModel
    {
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool IsEdited { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsRead { get; set; }
        public string? Text { get; set; }
        public int FromId { get; set; }
        public int ToUserId { get; set; }
    }
}
