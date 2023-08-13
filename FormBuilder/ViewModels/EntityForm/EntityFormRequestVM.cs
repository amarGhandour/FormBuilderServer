using System.ComponentModel.DataAnnotations;

namespace FormBuilder.ViewModels.EntityForm
{
    public class EntityFormRequestVM
    {
        [Required]
        public string formName { get; set; }

        [Required]
        public Guid EntityId { get; set; }

        [Required]
        public string formJson { get; set; }

    }
}
