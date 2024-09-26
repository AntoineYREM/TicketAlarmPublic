using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Persistence;

namespace TicketAlarm.Persistence.Repositories
{
    public  class GenericRepository<T> : IGenericRepository<T> where T : class 
    {
        private readonly TicketAlarmDbContext _dataBaseContext;

        public GenericRepository(TicketAlarmDbContext context)
        {
            _dataBaseContext = context;
        }

        public IQueryable<T> GetAll()
        {
            return this.GetAll(null, null, null, null, null);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return this.GetAll(predicate, null, null, null, null);
        }

        public IQueryable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> include)
        {
            return this.GetAll(null, include, null, null, null);
        }

        public Task<IQueryable<T>> GetAllAsync()
        {
            return this.GetAllAsync(null, null, null, null, null);
        }

        public Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return this.GetAllAsync(predicate, null, null, null, null);
        }

        public Task<IQueryable<T>> GetAllAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>> include)
        {
            return this.GetAllAsync(null, include, null, null, null);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null,
                                        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return GetQueryable(predicate, include);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null,
          Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
          int? skip = null, int? take = null)
        {
            IQueryable<T> query = GetQueryable(predicate, include);

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip != null && skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take != null && take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null,
                                     Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                    Expression<Func<T, bool>> orderBy = null, bool descending = false,
                                     int? skip = null, int? take = null)
        {
            IQueryable<T> query = GetQueryable(predicate, include);

            if (orderBy != null)
            {
                if (descending)
                    query = query.OrderByDescending(orderBy);
                else
                    query = query.OrderBy(orderBy);
            }

            if (skip != null && skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take != null && take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null,
                                                 Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                                 Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                 int? skip = null, int? take = null)
        {
            IQueryable<T> query = GetQueryable(predicate, include);

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip != null && skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take != null && take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return await Task.FromResult(query);
        }

        public Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null,
                                                Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return new Task<IQueryable<T>>(() => GetQueryable(predicate, include));
        }

        public Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null,
         Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
        Expression<Func<T, bool>> orderBy = null, bool descending  = false,
         int? skip = null, int? take = null)
        {
            IQueryable<T> query = GetQueryable(predicate, include);

            if (orderBy != null)
            {
                if(descending)
                    query = query.OrderByDescending(orderBy);
                else
                    query = query.OrderBy(orderBy);
            }

            if (skip != null && skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take != null && take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return new Task<IQueryable<T>>(() => query);
        }

        /// <summary>
        /// Returns a single instance of T but throws exception if none is found
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public T GetSingle(
         Expression<Func<T, bool>> predicate = null,
         Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = GetQueryable(predicate, include);

            return query.FirstOrDefault();
        }

        public Task<T> GetSingleAsync(
          Expression<Func<T, bool>> predicate = null,
          Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = GetQueryable(predicate, include);

            return query.FirstOrDefaultAsync();
        }

        //public virtual void Add(T entity)
        //{
        //    var result = _dataBaseContext.Set<T>().Add(entity);
        //}

        //public virtual void AddAsync(T entity)
        //{
        //    _dataBaseContext.Set<T>().AddAsync(entity);
        //}

        public T Update(T entity)
        {
            _dataBaseContext.Set<T>().Update(entity);
            return entity;
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
            var entity = GetSingle(predicate: predicate);
            _dataBaseContext.Set<T>().Remove(entity);
        }

        public void Delete(T entity)
        {
            _dataBaseContext.Set<T>().Remove(entity);
        }

        public int Count()
        {
            return _dataBaseContext.Set<T>().Count();
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return _dataBaseContext.Set<T>().Count(predicate);
        }

        private IQueryable<T> GetQueryable(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _dataBaseContext.Set<T>();

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query;
        }

        public T Add(T toAdd)
        {
            var result = _dataBaseContext.Set<T>().Add(toAdd);
            return result.Entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            var result = await _dataBaseContext.Set<T>().AddAsync(entity);
            return result.Entity;
        } 
    }
}
