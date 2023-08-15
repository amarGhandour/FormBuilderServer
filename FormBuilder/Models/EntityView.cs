using System.ComponentModel.DataAnnotations.Schema;

namespace FormBuilder.Models
{
    public class EntityView
    {
        public Guid EntityViewId { get; set; }

        public string Name { get; set; }

        [ForeignKey("EntitySchema")]
        public Guid EntitySchemaId { get; set; }

        public EntitySchema EntitySchema { get; set; }
    }
}
