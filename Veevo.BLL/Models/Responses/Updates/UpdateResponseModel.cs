using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veevo.BLL.Models.Database;
using Veevo.BLL.Models.Responses.Models;

namespace Veevo.BLL.Models.Responses.Updates
{
    public class UpdateResponseModel : BaseResponseModel
    {
        public IEnumerable<UpdateDatabaseModel>? Updates { get; set; }
    }
}
