using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Model
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Name field is empty")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname field is empty")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Phonenumber field is empty")]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "Password field is empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Both passwords should match")]
        public string ConfirmPassword { get; set; }
    }
}
