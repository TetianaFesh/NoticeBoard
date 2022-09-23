using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticeBoard.Dto
{
    public class NoticeItemTypeDto
    {
        public SelectList NoticeItemTypeList { get; set; }
    }
}
