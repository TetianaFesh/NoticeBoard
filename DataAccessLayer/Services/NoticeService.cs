using DataAccessLayer.Interfaces;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Services
{
    public class NoticeService : INoticeService
    {
        private readonly NoticeBoardContext _context;

        public NoticeService(NoticeBoardContext context)
        {
            _context = context;
        }
        public List<Notice> GetNotice()
        {
            List<Notice> notice = new List<Notice>();
            foreach (var n in _context.Notice.ToList())
            {
                notice.Add(n);
            }
            return notice;
        }
    }
}
