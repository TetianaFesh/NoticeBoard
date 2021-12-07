using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticeBoard.Dto
{
    public class FullComment
    {
        public int CommentId { get; set; }
        public String CommentText { get; set; }
        public int UserId { get; set; }
        public String UserName { get; set; }
    }
}
