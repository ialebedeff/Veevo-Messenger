using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veevo.BLL.Models.Requests
{
    public class GetUserRequestModel
    {
        public string? Username { get; set; }
        public int? Id { get; set; }
    }
}
