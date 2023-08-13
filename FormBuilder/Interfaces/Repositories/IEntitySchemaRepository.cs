using FormBuilder.Models;
using System.Linq.Expressions;

namespace FormBuilder.Interfaces.Repositories
{
    public interface IEntitySchemaRepository : IEntityBaseRepository<EntitySchema>
    {
        public Task<EntitySchema> GetByIdAsync(Guid id);

    }
}