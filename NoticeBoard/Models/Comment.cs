using System;
using System.Collections.Generic;

namespace NoticeBoard.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public int NoticeId { get; set; }
        public DateTime? Date { get; set; }
    }
}
