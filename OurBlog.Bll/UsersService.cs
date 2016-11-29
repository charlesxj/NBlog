using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OurBlog.Model;
using OurBlog.IBll;
using OurBlog.IDal;
using Microsoft.Practices.Unity.Utility;

namespace OurBlog.Bll
{
    public class UsersService : ServiceBase, IUsersService, IDisposable
    {
        //Repository都采用构造器注入的方式进行初始化
        public IUserRepository UserRepository { get; private set; }
        public UsersService(IUserRepository userRepository)
        {
            this.UserRepository = userRepository;
            this.AddDisposableObject(userRepository);
        }

        public users GetUsers(string FUSERNO)
        {
            Guard.ArgumentNotNullOrEmpty(FUSERNO, "FUSERNO");
            return this.UserRepository.GetUsers(FUSERNO);
        }

        public IEnumerable<users> GetUsers(int pageIndex, int pageSize, out int recordCount)
        {
            return this.UserRepository.GetUsers(pageIndex, pageSize, out recordCount);
        }

        public IEnumerable<users> GetLoginUsers(string loginname, string loginpwd)
        {
            Guard.ArgumentNotNullOrEmpty(loginname, "loginname");
            Guard.ArgumentNotNullOrEmpty(loginpwd, "loginpwd");
            return this.UserRepository.GetLoginUsers(loginname, loginpwd);
        }
    }
}