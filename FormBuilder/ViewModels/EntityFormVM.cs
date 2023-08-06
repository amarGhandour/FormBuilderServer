using FormBuilder.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FormBuilder.ViewModels
{
    public class EntityFormVM
    {
        public int Id { get; set; }

        public string FormName { get; set; }

        public string EntityName { get; set; }

        public string FormJson { get; set; }
    }
}
