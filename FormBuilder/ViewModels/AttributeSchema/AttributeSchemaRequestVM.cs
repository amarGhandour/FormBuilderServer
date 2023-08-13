using FormBuilder.Models;
using System.ComponentModel.DataAnnotations;

namespace FormBuilder.ViewModels.AttributeSchema
{
    public class AttributeSchemaRequestVM
    {

        [Required]
        public Guid EntitySchemaId { get; set; }

        [Required]
        public string LogicalName { get; set; }

        [Required]
        public string DisplayName { get; set; }

        public bool IsRequired { get; set; }

        public bool IsSearchable { get; set; }

        public int? MaxLen { get; set; }

        public int? MinLen { get; set; }

        [Required]
        public Guid AttributeTypeId { get; set; }

        public Guid optionSetTypeId { get; set; }

    }
}
