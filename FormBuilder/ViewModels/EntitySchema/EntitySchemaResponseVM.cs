using FormBuilder.Models;
using FormBuilder.ViewModels.AttributeSchema;

namespace FormBuilder.ViewModels.EntitySchema
{
    public class EntitySchemaResponseVM
    {
        public string EntitySchemaId { get; set; }

        public string EntityName { get; set; }

        public int EntityCode { get; set; }

        public ICollection<AttributeSchemaResponseVM> AttributeSchemas { get; set; } = new HashSet<AttributeSchemaResponseVM>();
    }
}
