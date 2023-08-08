using FormBuilder.Interfaces.Repositories;
using FormBuilder.Models;
using Microsoft.EntityFrameworkCore;

namespace FormBuilder.Repositories
{
    public class EntitySchemaRepository : BaseEntityRepository<EntitySchema>, IEntitySchemaRepository
    {
        public EntitySchemaRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<EntitySchema> GetByIdAsync(int id)
        {
            return await _context.entitySchemas.Include(e => e.AttributeSchemas).ThenInclude(e => e.AttributeType)
                
                .Where(e => e.EntitySchemaId == id).FirstOrDefaultAsync();
        }
    }
}
