using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticeBoard.Dto
{
    public class NoticeDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime Date { get; set; }
        public String Type { get; set; }
        public String ItemType { get; set; }
    }
}
