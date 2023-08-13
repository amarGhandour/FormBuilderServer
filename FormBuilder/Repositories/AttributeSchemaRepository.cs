using FormBuilder.Interfaces.Repositories;
using FormBuilder.Models;

namespace FormBuilder.Repositories
{
    public class AttributeSchemaRepository : BaseEntityRepository<AttributeSchema>, IAttributeSchemaRepository
    {
        public AttributeSchemaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
