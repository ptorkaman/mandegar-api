using Mandegar.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mandegar.Repository.GenericRepositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> _dbSet { get; set; }
        protected MandegarDbContext _context { get; set; }

        public GenericRepository(MandegarDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            var entry = _context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
                _dbSet.Remove(entity);
            }

            entry.State = EntityState.Deleted;
        }

        public void DeleteRange(List<T> entities)
        {
            foreach (var item in entities)
            {
                Delete(item);
            }
        }

        public async Task Delete(int id)
        {
            T entity = await Get(id);

            if (entity != null)
            {
                Delete(entity);
            }
        }

        public async Task DeleteRange(List<int> ids)
        {
            foreach (var item in ids)
            {
                await Delete(item);
            }
        }

        public void Detach(T entity)
        {
            var entry = _context.Entry(entity);

            entry.State = EntityState.Detached;
        }

        public async Task<T> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IQueryable<T> Get()
        {
            return _dbSet;
        }

        public IQueryable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public IQueryable<T> GetWithInclude(string[] includeProperties)
        {
            IQueryable<T> query = _dbSet;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public IQueryable<T> Get<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> keySelector)
        {
            return _dbSet.Where(predicate).OrderBy(keySelector);
        }

        public IQueryable<T> Get(int take, int skip, string sort)
        {
            var entities = _dbSet
               .AsQueryable()
               .OrderBy(sort)
               .Skip(skip)
               .Take(take);

            return entities;
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate, int take, int skip, string sort)
        {
            var entities = _dbSet
                .Where(predicate)
                .OrderBy(sort)
                .Skip(skip)
                .Take(take);

            return entities;
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet.Where(predicate);
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
    }
}
