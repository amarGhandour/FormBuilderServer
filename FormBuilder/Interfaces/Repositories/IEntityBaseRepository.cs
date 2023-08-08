using System.Linq.Expressions;

namespace FormBuilder.Interfaces.Repositories
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase
    {
        Task<T> AddAsync(T entity);
        
        Task<bool> DeleteAsync<IDType>(IDType id);


        Task<T> EditAsync<IDType>( IDType id, T entity, Expression<Func<T, IDType>> keySelector);


        Task<IEnumerable<T>> GetAllAsync(bool withNoTracking = true, params Expression<Func<T, object>>[] includes);

        Task<T?> GetByIdAsync<IDType>(IDType id, params Expression<Func<T, object>>[] includes);



    }
}
