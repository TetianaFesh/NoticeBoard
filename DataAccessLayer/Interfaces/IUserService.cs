using Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface IUserService
    {
        void Create(User item);
        bool Login(User item);
    }
}
