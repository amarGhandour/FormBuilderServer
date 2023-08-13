using FormBuilder.Controllers.Api;
using FormBuilder.Interfaces;

namespace FormBuilder.Models
{


    public class AttributeType: IEntityBase, ISoftDeletable
    {
        public Guid AttributeTypeId { get; set; }

        public string AttributeName { get; set; }

        public string SqlType { get; set; }

        public ICollection<AttributeSchema> AttributeSchemas { get; set; } = new HashSet<AttributeSchema>();

    }
}
