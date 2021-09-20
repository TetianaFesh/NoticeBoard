using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Model
{
    public class LoginModel
    {
        [Required(ErrorMessage="Email field is empty.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password field is empty.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
