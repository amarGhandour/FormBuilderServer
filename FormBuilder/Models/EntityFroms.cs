using System.ComponentModel.DataAnnotations.Schema;
using FormBuilder.Interfaces;

namespace FormBuilder.Models
{
    public class EntityFroms: IEntityBase, ISoftDeletable
    {
        public Guid EntityFromsId { get; set; }

        public string EntityFromsName { get; set; }

        public Guid EntitySchemaId { get; set; }

        public EntitySchema EntitySchema { get; set; }

        public string FromJson { get; set; }
    }
}
