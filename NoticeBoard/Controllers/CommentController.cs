using Microsoft.AspNetCore.Mvc;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticeBoard.Controllers
{
    public class CommentController : Controller
    {
        private readonly NoticeBoardContext _context;

        public CommentController(NoticeBoardContext context)
        {
            _context = context;
        }

        // POST: Notices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Text, UserId, NoticeId")] Comment comment)
        {
            comment.Date = DateTime.Now;
            _context.Comment.Add(comment);
            await _context.SaveChangesAsync();
            var noticeId = comment.NoticeId;
            return RedirectToAction("Details", "Notices", new { Id = noticeId });
        }
    }
}
