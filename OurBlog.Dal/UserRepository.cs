using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity.Utility;
using OurBlog.Model;
using OurBlog.IDal;
using System.Linq.Expressions;

namespace OurBlog.Dal
{
    public class UserRepository : OurBlogRepository<user>, IUserRepository
    {
        public UserRepository(blogEntities context) : base(context)
        {
        }

        public user GetUsers(string FUSERNO)
        {
            Guard.ArgumentNotNullOrEmpty(FUSERNO, "FUSERNO");
            return this.Get(p => p.FUSERNO == FUSERNO).FirstOrDefault();
        }

        public IEnumerable<user> GetUsers(int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = this.DbSet.Count();
            return this.Get(p => true, pageIndex, pageSize, p => p.FUSERREGTIME, false);
        }

        //获取登录用户列表
        public IEnumerable<user> GetLoginUsers(string loginname, string loginpw)
        {
            Guard.ArgumentNotNullOrEmpty(loginname, "loginname");
            Guard.ArgumentNotNullOrEmpty(loginpw, "loginpw");
            return this.Get(p => p.FUSERNAME == loginname && p.FPASSWORD == loginpw);
        }

        //获取登录用户列表
        public IEnumerable<user> GetUsersByFilter<TOderKey>(Expression<Func<user, bool>> filter, int pageIndex, int pageSize, Expression<Func<user, TOderKey>> sortKeySelector, out int recordCount, bool isAsc = true)
        {
            Guard.ArgumentNotNull(filter, "predicate");
            recordCount = this.DbSet.Where<user>(filter).Count();
            return this.Get(filter, pageIndex, pageSize, sortKeySelector, isAsc);
        }

        public int AddUser(user instance)
        {
            Guard.ArgumentNotNull(instance, "predicate");
            return this.Add(instance);

        }

        public int EditUser(user instance)
        {
            Guard.ArgumentNotNull(instance, "predicate");
            return this.Update(instance);
        }
    }
}
