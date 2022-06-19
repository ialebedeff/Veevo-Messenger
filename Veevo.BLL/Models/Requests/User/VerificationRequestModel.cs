using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veevo.BLL.Models.Requests
{
    public class VerificationRequestModel
    {
        [Required(ErrorMessage = "Email is empty.")]
        public string? Email { get; set; }
    }
}
