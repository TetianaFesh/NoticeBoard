using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class Notice
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int FNoticeType { get; set; }
        public int? FNoticeItemType { get; set; }
    }
}
