using OurBlog.IDal;
using OurBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity.Utility;
using System.Linq.Expressions;

namespace OurBlog.Dal
{
    public class RoleRepository :OurBlogRepository<role>, IRoleRepository
    {
        public RoleRepository(blogEntities entity)
            :base(entity)
        {

        }
        public List<role> GetRoleList(Expression<Func<role, bool>> filter)
        {
            Guard.ArgumentNotNull(filter, "predicate");
            List<role> roles = new List<role>();
            roles = this.Get(filter).ToList();
            return roles;
        }

        public string AddRole(role r)
        {
            Guard.ArgumentNotNull(r, "AddRole Role r is Null");
            if (this.DbSet.Find(r.FROLEID)!=null)
            {
                return string.Format("编号为{0}的角色已经存在", r.FROLEID);
            }
            this.DbSet.Add(r);
            int count = this.DbContext.SaveChanges();
            return count > 0 ? string.Format("角色\"{0}\"添加成功", r.FROLENAME) :
                     string.Format("角色\"{0}\"添加失败", r.FROLENAME);
        }

        public string DeleteRole(int roleId,string roleName="")
        {
            Guard.ArgumentNotNullOrEmpty(roleName, "roleName");
            role r = Find(roleId, roleName);

            if (r==null)
            {
                return "Role不存在";
            }
            this.DbSet.Remove(r);
            int count = this.DbContext.SaveChanges();
            return count > 0 ? string.Format("角色\"{0}\"删除成功", r.FROLENAME) :
                     string.Format("角色\"{0}\"删除失败", r.FROLENAME);
        }

        public string UpdateRole(role r)
        {
            Guard.ArgumentNotNull(r, "Role r为null，禁止删除");
            this.DbContext.Entry<role>(r).State=System.Data.Entity.EntityState.Modified;
            int count = this.DbContext.SaveChanges();
            return count > 0 ? string.Format("角色\"{0}\"更新成功", r.FROLENAME) :
                     string.Format("角色\"{0}\"更新失败", r.FROLENAME);
        }

        private role Find(int roleId,string roleName)
        {
            if(string.IsNullOrWhiteSpace(roleName)&& roleId<0)
            {
                return null;
            }
            if(!string.IsNullOrWhiteSpace(roleName))
            {
                return this.DbSet.First(w => w.FROLENAME.Trim().Equals(roleName));
            }
            return this.DbSet.First(w => w.FROLEID == roleId);
        }
    }
}
