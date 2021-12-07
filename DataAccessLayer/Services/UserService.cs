using DataAccessLayer.Interfaces;
using Entities.Model;

namespace DataAccessLayer.Services
{
    public class UserService : IUserService
    {
        private NoticeBoardContext _context;
        public UserService(NoticeBoardContext context)
        {
            _context = context;
        }
        public void Create(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }

        public bool Login(User user)
        {
            User _user = _context.User.Find(user.Email);
            if (_user.Password == user.Password) {  

                return true;
            }
            return false;
        }

        public User GetUser(int? id)
        {
            return _context.User.Find(id);
        }
    }
}
