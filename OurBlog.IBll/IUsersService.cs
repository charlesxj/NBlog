using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OurBlog.Model;
using System.Linq.Expressions;

namespace OurBlog.IBll
{
    public interface IUsersService
    {
        IEnumerable<user> GetUsers(int pageIndex, int pageSize, out int recordCount);
        user GetUsers(string FUSERNO);//假设FUSERNO唯一
        IEnumerable<user> GetLoginUsers(string loginname, string loginpw);//获取登录用户列表
        IEnumerable<user> GetUsersByFilter<TOderKey>(Expression<Func<user, bool>> filter, int pageIndex, int pageSize, Expression<Func<user, TOderKey>> sortKeySelector, out int recordCount, bool isAsc = true);
    }
}