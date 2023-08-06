namespace FormBuilder.Models
{
    public class EntitySchema: IEntityBase
    {
        public int EntitySchemaId { get; set; }

        public string EntityName { get; set; }

        public int EntityCode { get; set; }

        public ICollection<AttributeSchema> AttributeSchemas { get; set; } = new HashSet<AttributeSchema>();
    }
}
