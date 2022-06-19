using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veevo.Kernel.Models.Requests
{
    public class LoginRequestModel
    {
        public LoginRequestModel() : base() { }
        public LoginRequestModel(string? email, string? password)
        {
            Email = email;
            Password = password;
        }
        [Required(ErrorMessage = "Email is empty.")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is empty")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }    
    }
}
