using FormBuilder.Controllers.Api;
using FormBuilder.Interfaces;

namespace FormBuilder.Models
{
    public class OptionSetValue : IEntityBase, ISoftDeletable
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public string Name { get; set; }

        public ICollection<AttributeSchemaOptionSetValue> AttributeTypesOptionSetValues { get; set; } = new HashSet<AttributeSchemaOptionSetValue>();
    }
}
