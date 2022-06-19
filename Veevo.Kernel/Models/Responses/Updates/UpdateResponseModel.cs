using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veevo.Kernel.Models.Entities;

namespace Veevo.Kernel.Models.Responses.Updates
{
    public class UpdateResponseModel : BaseResponseModel
    {
        public IEnumerable<UpdateModel>? Updates { get; set; }
    }
}
