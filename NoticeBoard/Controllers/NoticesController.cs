using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using NoticeBoard.Models;
using Entities.Model;
using AutoMapper;
using NoticeBoard.Dto;
using System.Security.Claims;

namespace NoticeBoard.Controllers
{
    public class NoticesController : Controller
    {
        private readonly NoticeBoardContext _context;

        public NoticesController(NoticeBoardContext context)
        {
            _context = context;
        }

        // GET: Notices
        public async Task<IActionResult> Index()
        {
            SelectList selectListNoticeType = new SelectList(_context.NoticeType, "Id", "TypeName");
            SelectList selectListNoticeItemType = new SelectList(_context.NoticeItemType, "Id", "Name");

            ViewBag.NoticeType = selectListNoticeType;
            ViewBag.NoticeItemType = selectListNoticeItemType;

            return View(await _context.Notice.OrderByDescending(m => m.Date).ToListAsync());
        }

        // GET: Notices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SelectList selectListNoticeType = new SelectList(_context.NoticeType, "Id", "TypeName");
            SelectList selectListNoticeItemType = new SelectList(_context.NoticeItemType, "Id", "Name");

            ViewBag.NoticeType = selectListNoticeType;
            ViewBag.NoticeItemType = selectListNoticeItemType;

            var notice = await _context.Notice 
                .FirstOrDefaultAsync(m => m.Id == id);
            var user = await _context.User.FirstOrDefaultAsync(m => m.Id == notice.UserId);
            var comment = _context.Comment.Where(m => m.NoticeId == id).OrderByDescending(m => m.Date);
            var itemType = await _context.NoticeItemType.FirstOrDefaultAsync(m => m.Id == notice.FNoticeItemType);
            var noticeType = await _context.NoticeType.FirstOrDefaultAsync(m => m.Id == notice.FNoticeType);
            FullNotice fullNotice = new FullNotice
            {
                Text = notice.Text,
                Date = notice.Date.ToShortDateString(),
                NoticeId = notice.Id,
                FNoticeItemType = itemType.Name,
                FNoticeType = noticeType.TypeName,
                UserId = user.Id,
                UserName = user.Name + " " + user.Surname,
               // UserNameForComment = userComment.Name + " " + userComment.Surname,
                FullComments = new List<FullComment>()
            };

            foreach (var comm in comment)
            {
                var userComment = await _context.User.FirstOrDefaultAsync(m => m.Id == comm.UserId);
                fullNotice.FullComments.Add(new FullComment { CommentId = comm.Id, CommentText = comm.Text, UserId = userComment.Id, UserName = userComment.Name + " " + userComment.Surname });
            }

            if (notice == null)
            {
                return NotFound();
            }

            return View(fullNotice);
        }

        // GET: Notices/Create
        public IActionResult Create()
        {
            SelectList selectListNoticeType = new SelectList(_context.NoticeType, "Id", "TypeName");
            SelectList selectListNoticeItemType = new SelectList(_context.NoticeItemType, "Id", "Name");

            ViewBag.NoticeType = selectListNoticeType;
            ViewBag.NoticeItemType = selectListNoticeItemType;

            return View();
        }

        // POST: Notices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Name, Type, ItemType")] NoticeDto noticeDto)
        {

            Notice notice = new Notice();
            if (ModelState.IsValid)
            { 
                notice.UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                notice.FNoticeType = int.Parse(noticeDto.Type);
                notice.FNoticeItemType = int.Parse(noticeDto.ItemType);
                notice.Text = String.IsNullOrEmpty(noticeDto.Name) ? "Test faild empty text field" : noticeDto.Name;
                notice.Date = DateTime.Now;
                _context.Add(notice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notice);
        }

        // GET: Notices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notice = await _context.Notice.FindAsync(id);
            if (notice == null)
            {
                return NotFound();
            }

            SelectList selectListNoticeType = new SelectList(_context.NoticeType, "Id", "TypeName", notice.FNoticeType);
            SelectList selectListNoticeItemType = new SelectList(_context.NoticeItemType, "Id", "Name", notice.FNoticeItemType);

            ViewBag.NoticeType = selectListNoticeType;
            ViewBag.NoticeItemType = selectListNoticeItemType;

            NoticeDto noticeDto = new NoticeDto
            {
                Id = notice.Id,
                Date = notice.Date,
                Name = notice.Text,
            };
            return View(noticeDto);
        }

        // POST: Notices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Date, Type, ItemType")] NoticeDto noticeDto)
        {
            if (id != noticeDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Notice notice = new Notice();
                    notice.Id = noticeDto.Id;
                    notice.Date = noticeDto.Date;
                    notice.UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                    notice.FNoticeType = int.Parse(noticeDto.Type);
                    notice.FNoticeItemType = int.Parse(noticeDto.ItemType);
                    notice.Text = String.IsNullOrEmpty(noticeDto.Name) ? "Test faild empty text field" : noticeDto.Name;
                    _context.Update(notice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoticeExists(noticeDto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(noticeDto);
        }

        // GET: Notices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notice = await _context.Notice
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notice == null)
            {
                return NotFound();
            }

            return View(notice);
        }

        // POST: Notices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notice = await _context.Notice.FindAsync(id);
            _context.Notice.Remove(notice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoticeExists(int id)
        {
            return _context.Notice.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Search(String Type, String ItemType)
        {
            SelectList selectListNoticeType = new SelectList(_context.NoticeType, "Id", "TypeName");
            SelectList selectListNoticeItemType = new SelectList(_context.NoticeItemType, "Id", "Name");

            ViewBag.NoticeType = selectListNoticeType;
            ViewBag.NoticeItemType = selectListNoticeItemType;

            var typeId = 0;
            var itemTypeId = 0;
            if (Type != "None" && ItemType != "None")
            {
                typeId = _context.NoticeType.FirstOrDefault(m => m.Id.ToString() == Type).Id;
                itemTypeId = _context.NoticeItemType.FirstOrDefault(m => m.Id.ToString() == ItemType).Id;

                var notices = _context.Notice.Where(m => m.FNoticeType == typeId && m.FNoticeItemType == itemTypeId);
                if(notices.Count() == 0)
                {
                    return View("ErrorPage");
                }
                return View("Index", notices);

            }
            else if(Type == "None" && ItemType != "None")
            {
                itemTypeId = _context.NoticeItemType.FirstOrDefault(m => m.Name == ItemType).Id;

                var notices = _context.Notice.Where(m => m.FNoticeItemType == itemTypeId);
                if (notices.Count() == 0)
                {
                    return View("ErrorPage");
                }
                return View("Index", notices);
            }
            else if (ItemType == "None" && Type != "None")
            {
                typeId = _context.NoticeType.FirstOrDefault(m => m.TypeName == Type).Id;

                var notices = _context.Notice.Where(m => m.FNoticeType == typeId);
                if (notices.Count() == 0)
                {
                    return View("ErrorPage");
                }
                return View("Index", notices);
            }
            return View("ErrorPage");
        }

        public async Task<IActionResult> MyNotices(int id)
        {
            var myNotices = _context.Notice.Where(m => m.UserId == id);
            if (myNotices.Count() == 0)
            {
                return View("ErrorPage");
            }
            return View("Index", myNotices);
        }
    }
}
