﻿using OurBlog.Model;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace OurBlog.IDal
{
    public interface IUserRepository
    {
        IEnumerable<user> GetUsers(int pageIndex, int pageSize, out int recordCount);
        user GetUsers(string FUSERNO);//假设FUSERNO唯一
        IEnumerable<user> GetLoginUsers(string loginname, string loginpw);//获取登录用户列表
        IEnumerable<user> GetUsersByFilter<TOderKey>(Expression<Func<user, bool>> filter, int pageIndex, int pageSize, Expression<Func<user, TOderKey>> sortKeySelector, out int recordCount, bool isAsc = true);
        int AddUser(user instance);
        int EditUser(user instance);
    }
}