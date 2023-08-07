using FormBuilder.Interfaces;

namespace FormBuilder.Models
{
    public class EntitySchema: IEntityBase, ISoftDeletable
    {
        public int EntitySchemaId { get; set; }

        public string EntityName { get; set; }

        public int EntityCode { get; set; }

        public ICollection<AttributeSchema> AttributeSchemas { get; set; } = new HashSet<AttributeSchema>();
    }
}
