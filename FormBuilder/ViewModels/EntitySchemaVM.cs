using FormBuilder.Models;

namespace FormBuilder.ViewModels
{
    public class EntitySchemaVM
    {
        public int EntitySchemaId { get; set; }

        public string EntityName { get; set; }

        public int EntityCode { get; set; }

        public ICollection<AttributeSchemaVM> AttributeSchemas { get; set; } = new HashSet<AttributeSchemaVM>();
    }
}
