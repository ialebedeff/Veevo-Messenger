using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veevo.BLL.Models.Requests
{
    public class RegistrationRequestModel
    {
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Not a email address")]
        public string Email { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be greater then 8 characters")]
        public string Password { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be greater then 8 characters")]
        [Compare(nameof(Password), ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; }
    }
}
