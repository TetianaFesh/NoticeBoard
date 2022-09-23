using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Model;
using DataAccessLayer.Interfaces;
using NoticeBoard.Dto;
using System.Text;
using System.Security.Cryptography;
using System;
//using NoticeBoard.Models;

namespace NoticeBoard.Controllers
{
    public class UsersController : Controller
    {
        private readonly NoticeBoardContext _context;
        private IUserService _userService;

        public UsersController(NoticeBoardContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public async Task<IActionResult> Profile(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return View("Profile", user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int Id, string Name, string Surname, string Password, string Telefon, string Email)
        {

            User user = _context.User.FirstOrDefault(u => u.Email == Email);
            //переводим строку в байт-массим  
            byte[] bytes = Encoding.Unicode.GetBytes(Password);
            //создаем объект для получения средст шифрования  
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            //вычисляем хеш-представление в байтах  
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = string.Empty;
            //формируем одну цельную строку из массива  
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            if (ModelState.IsValid)
            {
                if (user == null)
                {
                    user = new User { Name = Name, Surname = Surname, Telefon = Telefon, Email = Email, Password = new Guid(hash), Admin = 0 };

                    _userService.Create(user);

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "User with this email already exist.");
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Password,Email,Telefon")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var useRole = _context.User.Where(m => m.Id == id).Select(m => m.Admin);
                    if (useRole.FirstOrDefault() == 1)
                    {
                        user.Admin = 1;
                    }
                    else{
                        user.Admin = 0;
                    }
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Notices");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }

        public async Task<IActionResult> SetAdminRole(int id)
        {
            var user = _userService.GetUser(id);
            user.Admin = 1;
            _context.User.Update(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteFromAdmin(int id)
        {
            var user = _userService.GetUser(id);
            user.Admin = 0;
            _context.User.Update(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }   
    }
}
