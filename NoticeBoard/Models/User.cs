using System;
using System.Collections.Generic;

namespace NoticeBoard.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Guid Password { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public int? Admin { get; set; }
    }
}
