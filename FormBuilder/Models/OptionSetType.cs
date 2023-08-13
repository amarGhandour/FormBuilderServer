namespace FormBuilder.Models
{
    public class OptionSetType
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsGlobal { get; set; }

        public ICollection<OptionSetValue> OptionSetValues { get; set; } = new HashSet<OptionSetValue>();

        public ICollection<AttributeSchema> AttributeSchemas { get; set; } = new HashSet<AttributeSchema>();
    }
}
