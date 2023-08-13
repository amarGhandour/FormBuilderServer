using FormBuilder.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FormBuilder.ViewModels.AttributeSchema
{
    public class AttributeSchemaResponseVM
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public bool IsRequired { get; set; }

        public int? MaxLen { get; set; }

        public int? MinLen { get; set; }
        public bool Searchable { get; set; } = false;

        public string Type { get; set; }

        public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();

    }
}
