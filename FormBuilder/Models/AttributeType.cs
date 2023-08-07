using FormBuilder.Controllers.Api;
using FormBuilder.Interfaces;

namespace FormBuilder.Models
{


    public class AttributeType: IEntityBase, ISoftDeletable
    {
        public int AttributeTypeId { get; set; }

        public string AttributeName { get; set; }

        public string SqlType { get; set; }

    }
}
