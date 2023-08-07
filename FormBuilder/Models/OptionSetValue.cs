using FormBuilder.Controllers.Api;

namespace FormBuilder.Models
{
    public class OptionSetValue
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public string Name { get; set; }

        public ICollection<AttributeSchemaOptionSetValue> AttributeTypesOptionSetValues { get; set; } = new HashSet<AttributeSchemaOptionSetValue>();
    }
}
