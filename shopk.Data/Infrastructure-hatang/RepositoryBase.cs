﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace shopk.Data.Infrastructure_hatang
{
    public abstract class RepositoryBase<T> where T : class
    {
        private MyDbContext dataContext;
        private readonly IDbSet<T> dbSet;
        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected MyDbContext DbContext
        {
            get
            {
                return dataContext ?? (dataContext = DbFactory.Init());
            }
        }

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void DeleteMulti(Expression<Func<T,bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
            {
                dbSet.Remove(obj);
            }
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual T GetSingleById(int id)
        {
            return dbSet.Find(id);
        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T,bool>> where, string includes)
        {
            return dbSet.Where(where).ToList();
        }

        public virtual int Count(Expression<Func<T,bool>> where)
        {
            return dbSet.Count(where);
        }

        public IQueryable<T> GetAll(string[] includes = null)
        {
            //Handle includes for associated objects if applicable
            if (includes != null && includes.Count() > 0)
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.AsQueryable();
            }
            return dataContext.Set<T>().AsQueryable();
        }

        public T GetSingleByCondition(Expression<Func<T,bool>> expression, string[] includes = null)
        {
            return GetAll(includes).FirstOrDefault(expression);
        }

        public virtual IQueryable<T> GetMulti(Expression<Func<T,bool>> predicate, string[] includes = null)
        {
            //Handle includes for associated objects if applicable
            if (includes != null && includes.Count() > 0)
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.Where<T>(predicate).AsQueryable<T>();
            }
            return dataContext.Set<T>().Where<T>(predicate).AsQueryable<T>();
        }

        //public virtual IQueryable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null)
        //{
        //    int skipCount = index * size;
        //    IQueryable<T> _resetSet;
        //    //Handle includes for associated objects if applicable
        //    if (includes != null && includes.Count() > 0)
        //    {
        //        var query = dataContext.Set<T>().Include(includes.First());
        //        foreach (var include in includes.Skip(1))
        //            query = query.Include(include);
        //        _resetSet = pre
        //    }
        //    return dataContext.Set<T>().AsQueryable();
        //}
    }
}
