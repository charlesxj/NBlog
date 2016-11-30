using OurBlog.Model;
using System.Collections.Generic;

namespace OurBlog.IDal
{
    public interface IUserRepository
    {
        IEnumerable<user> GetUsers(int pageIndex,int pageSize,out int recordCount);
        user GetUsers(string FUSERNO);//假设FUSERNO唯一
        IEnumerable<user> GetLoginUsers(string loginname, string loginpw);//获取登录用户列表
    }
}