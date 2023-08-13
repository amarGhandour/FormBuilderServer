using FormBuilder.Interfaces;

namespace FormBuilder.Models
{
    public class EntitySchema: IEntityBase, ISoftDeletable
    {
        public Guid EntitySchemaId { get; set; }

        public string EntityName { get; set; }
        public string DisplayName { get; set; }
        public int EntityCode { get; set; }

        public ICollection<AttributeSchema> AttributeSchemas { get; set; } = new HashSet<AttributeSchema>();

        public ICollection<EntityFroms> EntityFroms { get; set; } = new HashSet<EntityFroms>();
    }
}
