using System;
using System.Collections.Generic;
using OurBlog.Model;
using OurBlog.IBll;
using OurBlog.IDal;
using Microsoft.Practices.Unity.Utility;
using System.Linq.Expressions;

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

        public user GetUsers(string FUSERNO)
        {
            return this.UserRepository.GetUsers(FUSERNO);
        }

        public IEnumerable<user> GetUsers(int pageIndex, int pageSize, out int recordCount)
        {
            return this.UserRepository.GetUsers(pageIndex, pageSize, out recordCount);
        }

        public IEnumerable<user> GetLoginUsers(string loginname, string loginpwd)
        {
            return this.UserRepository.GetLoginUsers(loginname, loginpwd);
        }

        public IEnumerable<user> GetUsersByFilter<TOderKey>(Expression<Func<user, bool>> filter, int pageIndex, int pageSize, Expression<Func<user, TOderKey>> sortKeySelector, out int recordCount, bool isAsc = true)
        {
            return this.UserRepository.GetUsersByFilter(filter, pageIndex, pageSize, sortKeySelector, out recordCount, isAsc);
        }

        public int AddUser(user instance)
        {
            return this.UserRepository.AddUser(instance);
        }

        public int EditUser(user instance)
        {
            return this.UserRepository.EditUser(instance);
        }

        /// <summary>
        /// 更加条件刷选数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        //public IEnumerable<user> GetUsers(int pageIndex, int pageSize, out int recordCount)
        //{
        //    return this.UserRepository.GetUsers(pageIndex, pageSize, out recordCount);
        //}
    }
}