using System.ComponentModel.DataAnnotations.Schema;

namespace FormBuilder.Models
{
    public class EntityFroms
    {
        public int EntityFromsId { get; set; }

        public string EntityFromsName { get; set; }

        [ForeignKey("EntitySchema")]
        public int EntitySchemaId { get; set; }

        public EntitySchema EntitySchema { get; set; }

        public string FromJson { get; set; }
    }
}
