using FormBuilder.Interfaces.Repositories;
using FormBuilder.Models;

namespace FormBuilder.Repositories
{
    public class EntityFormRepository : BaseEntityRepository<EntityFroms>, IEntityFormRepository
    {
        public EntityFormRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
