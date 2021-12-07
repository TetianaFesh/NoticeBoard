using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticeBoard.Dto
{
    public class FullNotice
    {
        public int NoticeId { get; set; }
        public string Text { get; set; }
        public String Date { get; set; }
        public String UserName { get; set; }
        public int UserId { get; set; }
        public string FNoticeType { get; set; }
        public String FNoticeItemType { get; set; }
        public String UserNameForComment { get; set; }
        public string CommentText { get; set; }
        public List<FullComment> FullComments { get; set; }
    }
}
