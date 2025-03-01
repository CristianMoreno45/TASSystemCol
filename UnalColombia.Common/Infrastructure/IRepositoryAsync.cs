using System.Linq.Expressions;

namespace UnalColombia.Common.Infrastructure
{

    public interface IRepositoryAsync<T> where T : class
    {
        Task<T> GetByIdAsync(object id);
        IEnumerable<T> GetByFilter(Expression<Func<T, bool>> filter);

        Task AddAsync(IEnumerable<T> entities);
        Task<bool> Add(IEnumerable<T> entities);

        Task AddAsync(T entity);
        Task<T> Add(T entity);

        Task UpdateAsync(T entity);
        Task<bool> Update(T entity);

        Task DeleteAsync(object id);
        Task<bool> Delete(object id);

        Task SaveChangesAsync();


    }
}
