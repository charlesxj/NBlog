using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OurBlog.Model;

namespace OurBlog.IBll
{
    public interface IUsersService
    {
        IEnumerable<user> GetUsers(int pageIndex, int pageSize, out int recordCount);
        user GetUsers(string FUSERNO);//假设FUSERNO唯一
        IEnumerable<user> GetLoginUsers(string loginname, string loginpw);//获取登录用户列表
    }
}