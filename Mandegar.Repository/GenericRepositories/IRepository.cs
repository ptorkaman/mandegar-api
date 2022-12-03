using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mandegar.Repository.GenericRepositories
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(List<T> entities);
        Task Delete(int id);
        Task DeleteRange(List<int> ids);
        void Detach(T entity);
        Task<T> Get(int id);
        IQueryable<T> Get();
        IQueryable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> GetWithInclude(string[] includeProperties);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        IQueryable<T> Get<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> keySelector);
        IQueryable<T> Get(int take, int skip, string sort);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate, int take, int skip, string sort);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
    }
}
