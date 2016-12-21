using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurBlog.Model;
using OurBlog.IBll;
using OurBlog.IDal;

namespace OurBlog.Bll
{
    public class RoleService : IBll.ServiceBase, IBll.IRoleService
    {
        public IRoleRepository RoleRepository { get; private set; }

        public RoleService(IRoleRepository repository)
        {
            this.RoleRepository = repository;
            this.AddDisposableObject(this.RoleRepository);
        }
         
        public List<role> GetRoleList(System.Linq.Expressions.Expression<Func<role, bool>> filter)
        {
            return RoleRepository.GetRoleList(filter);
        }

        public string AddRole(Model.role r)
        {
            return RoleRepository.AddRole(r);
        }

        public string DeleteRole(int roleId, string roleName = "")
        {
            return RoleRepository.DeleteRole(roleId, roleName);
        }

        public string UpdateRole(role r)
        {
            return RoleRepository.UpdateRole(r);
        }
    }
}
