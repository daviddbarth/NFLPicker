using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DataAccess
{
    public interface IRepository<T> where T : class
    {
        Task InsertAsync(T entity);
        Task<List<T>> FindAllAsync();
        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate, List<string> excludeFields);
        Task<T> FindByIdAsync(string id);
        Task<bool> Exists(Expression<Func<T, bool>> predicate);
        Task ReplaceOneAsync(Expression<Func<T, bool>> predicate, T entity);
        Task UpdateByIdAsync(T entity);
        Task SaveAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteByIdAsync(string id);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);
    }

}
