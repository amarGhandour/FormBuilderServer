using FormBuilder.Models;
using FormBuilder.ViewModels.AttributeSchema;

namespace FormBuilder.ViewModels.EntitySchema
{
    public class EntitySchemaVM
    {
        public int EntitySchemaId { get; set; }

        public string EntityName { get; set; }

        public int EntityCode { get; set; }

        public ICollection<AttributeSchemaVM> AttributeSchemas { get; set; } = new HashSet<AttributeSchemaVM>();
    }
}
