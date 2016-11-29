using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using OurBlog.Model;
using System.Data;
using Microsoft.Practices.Unity.Utility;
using System.Data.Entity;

namespace OurBlog.IDal
{
    public class OurBlogRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public blogEntities DbContext { get; set; }
        public DbSet<TEntity> DbSet { get; private set; }
        public OurBlogRepository(blogEntities context)
        {
            Guard.ArgumentNotNull(context, "context");
            this.DbContext = context;
            this.DbSet = this.DbContext.Set<TEntity>();
        }
        public IEnumerable<TEntity> Get()
        {
            return this.DbSet.AsQueryable();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return this.DbSet.Where(filter).AsQueryable();
        }

        public IEnumerable<TEntity> Get<TOderKey>(Expression<Func<TEntity, bool>> filter, int pageIndex, int pageSize, Expression<Func<TEntity, TOderKey>> sortKeySelector, bool isAsc = true)
        {
            Guard.ArgumentNotNull(filter, "predicate");
            Guard.ArgumentNotNull(sortKeySelector, "sortKeySelector");
            if (isAsc)
            {
                return this.DbSet
                    .Where(filter)
                    .OrderBy(sortKeySelector)
                    .Skip(pageSize * (pageIndex - 1))
                    .Take(pageSize).AsQueryable();
            }
            else
            {
                return this.DbSet
                    .Where(filter)
                    .OrderByDescending(sortKeySelector)
                    .Skip(pageSize * (pageIndex - 1))
                    .Take(pageSize).AsQueryable();
            }
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return this.DbSet.Where(predicate).Count();
        }

        public int Add(TEntity instance)
        {
            Guard.ArgumentNotNull(instance, "instance");
            this.DbSet.Attach(instance);
            this.DbContext.Entry(instance).State = System.Data.Entity.EntityState.Added;
            return this.DbContext.SaveChanges();
        }

        public int Update(TEntity instance)
        {
            Guard.ArgumentNotNull(instance, "instance");
            this.DbSet.Attach(instance);
            this.DbContext.Entry(instance).State = System.Data.Entity.EntityState.Modified;
            return this.DbContext.SaveChanges();
        }

        public int Delete(TEntity instance)
        {
            Guard.ArgumentNotNull(instance, "instance");
            this.DbSet.Attach(instance);
            this.DbContext.Entry(instance).State = System.Data.Entity.EntityState.Deleted;
           return this.DbContext.SaveChanges();
        }

        public void Dispose()
        {
            this.DbContext.Dispose();
        }

       
    }
}