using System.Linq.Expressions;

namespace FormBuilder.Interfaces.Repositories
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase
    {
        Task<T> AddAsync(T entity);
        
        Task<bool> DeleteAsync<IDType>(IDType id);


        Task<T> EditAsync<IDType>( IDType id, T entity, Expression<Func<T, IDType>> keySelector);

        //Task<T> EditAsync<IDType1, IDType2, Property>(IDType1 id1,IDType2 id2, Property propertySelect, T entity, Expression<Func<T, Property>> keySelector);

        Task<IEnumerable<T>> GetAllAsync(bool withNoTracking = true, params Expression<Func<T, object>>[] includes);

        Task<T?> GetByIdAsync<IDType>(IDType id, params Expression<Func<T, object>>[] includes);
         Task<T> FindAsync<IDType>(IDType id);


    }
}
