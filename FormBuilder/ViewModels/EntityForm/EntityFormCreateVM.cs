using System.ComponentModel.DataAnnotations;

namespace FormBuilder.ViewModels.EntityForm
{
    public class EntityFormCreateVM
    {
        [Required]
        public string formName { get; set; }

        [Required]
        public int EntityId { get; set; }

        [Required]
        public string formJson { get; set; }

    }
}
