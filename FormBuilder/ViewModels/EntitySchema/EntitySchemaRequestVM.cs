using System.ComponentModel.DataAnnotations;

namespace FormBuilder.ViewModels.EntitySchema
{
    public class EntitySchemaRequestVM
    {
        [Required]
        public string EntityName { get; set; }

        [Required]
        public int EntityCode { get; set; }
    }
}
