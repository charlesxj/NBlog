using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OurBlog.Model;

namespace OurBlog.IDal
{
    public interface IUserRepository
    {
        IEnumerable<users> GetUsers(int pageIndex,int pageSize,out int recordCount);
        users GetUsers(string FUSERNO);//假设FUSERNO唯一
        IEnumerable<users> GetLoginUsers(string loginname, string loginpw);//获取登录用户列表
    }
}