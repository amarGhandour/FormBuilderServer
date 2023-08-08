namespace FormBuilder.Models
{
    public class OptionSetType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsGlobal { get; set; }

        public ICollection<OptionSetValue> OptionSetValues { get; set; } = new HashSet<OptionSetValue>();

        //public ICollection<AttributeSchemaOptionSetType> AttributeSchemaOptionSetTypes { get; set; } = new HashSet<AttributeSchemaOptionSetType>();

        public ICollection<AttributeSchema> AttributeSchemas { get; set; } = new HashSet<AttributeSchema>();
    }
}
