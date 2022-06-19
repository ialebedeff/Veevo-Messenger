using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veevo.BLL.Models.Database;
using Veevo.BLL.Models.Responses.Models;

namespace Veevo.BLL.Models.Responses.Dialogs
{
    public class GetDialogsResponseModel : BaseResponseModel
    {
        public IEnumerable<DialogDatabaseModel>? Dialogs { get; set; }
    }
}
