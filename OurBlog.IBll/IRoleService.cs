using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using OurBlog.Model;

namespace OurBlog.IBll
{
    public interface IRoleService
    {
        List<role> GetRoleList(Expression<Func<role, bool>> filter);
        string AddRole(role r);
        string DeleteRole(int roleId, string roleName = "");
        string UpdateRole(role r);
    }
}
