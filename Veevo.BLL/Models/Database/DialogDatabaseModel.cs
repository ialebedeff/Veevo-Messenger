using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veevo.BLL.Models.Database
{
    public class DialogDatabaseModel
    {
        /// <summary>
        /// Id диалога
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Id пользователей участвующих в диалоге
        /// </summary>
        public List<int> Users { get; set; } = null!;
        /// <summary>
        /// Дата создания диалога
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Диалог удален или нет
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
