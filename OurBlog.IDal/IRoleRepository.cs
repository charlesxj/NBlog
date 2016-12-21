using OurBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OurBlog.IDal
{
    /// <summary>
    /// 新加角色接口
    /// </summary>
    public interface IRoleRepository
    {
        List<role> GetRoleList(Expression<Func<role, bool>> filter);
        string AddRole(role r);
        string DeleteRole(int roleId,string roleName="");
        string UpdateRole(role r);
    }
}
