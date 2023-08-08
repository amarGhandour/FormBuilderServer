using FormBuilder.Interfaces;
using FormBuilder.Interfaces.Repositories;
using FormBuilder.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Linq.Expressions;

namespace FormBuilder.Repositories
{
    public class BaseEntityRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase
    {
        protected readonly ApplicationDbContext _context;

        public BaseEntityRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public virtual async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<bool> DeleteAsync<IDType>(IDType id)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            if (entity == null)
            {
                return false;
            }

             _context.Set<T>().Remove(entity);

            return true;

        }

        public virtual async Task<T> EditAsync<IDType>(IDType id, T entity, Expression<Func<T, IDType>> keySelector)
        {
            var foundEntity = await _context.Set<T>().FindAsync(id);

            if (foundEntity == null) return null;

            _context.Entry(entity).Property(keySelector).CurrentValue = id;

            _context.Entry(foundEntity).CurrentValues.SetValues(entity);

            await _context.SaveChangesAsync();

            return foundEntity;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(bool withNoTracking = true, params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().AsQueryable();
            if (includes.Length > 0)
            {
                foreach (var include in includes)
                    query = query.Include(include);

            }
            if (withNoTracking == true)
                query.AsNoTracking();

            return await query.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync<IDType>(IDType id, params Expression<Func<T, object>>[] includes) { 
            var query = _context.Set<T>().AsQueryable();

            if (includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
         
            return await query.FirstOrDefaultAsync(e => e.GetType().GetProperty("Id").GetValue(e).Equals(id));

        }

        
    }
}
