using Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface INoticeService
    {
        List<Notice> GetNotice();
    }
}
