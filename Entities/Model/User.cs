using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Entities.Model
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Guid Password { get; set; }
        [DisplayName("Phone number")]
        public string Telefon { get; set; }
        public string Email { get; set; }
        public int? Admin { get; set; }
    }
}
