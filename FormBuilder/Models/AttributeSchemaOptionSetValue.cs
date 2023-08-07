using System.ComponentModel.DataAnnotations.Schema;
using FormBuilder.Interfaces;

namespace FormBuilder.Models
{
    public class AttributeSchemaOptionSetValue: IEntityBase
    {
        public int Id { get; set; }

        [ForeignKey("AttributeSchema")]
        public int AttributeSchemaId { get; set; }

        [ForeignKey("OptionSetValue")]
        public int OptionSetValueId { get; set; }

        public OptionSetValue OptionSetValue { get; set; }

        public AttributeSchema AttributeSchema { get; set; }

    }
}
