using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity.Utility;
using OurBlog.Model;
using OurBlog.IDal;

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
        IEnumerable<user> IUserRepository.GetLoginUsers(string loginname, string loginpw)
        {
            Guard.ArgumentNotNullOrEmpty(loginname, "loginname");
            Guard.ArgumentNotNullOrEmpty(loginpw, "loginpw");
            return this.Get(p => p.FUSERNAME == loginname && p.FPASSWORD == loginpw);
        }


    }
}
