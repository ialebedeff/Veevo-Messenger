using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veevo.Kernel.Models.Entities;

namespace Veevo.Kernel.Models.Responses.Dialogs
{
    public class GetDialogsResponseModel : BaseResponseModel
    {
        public List<DialogModel>? Dialogs { get; set; }
    }
}
