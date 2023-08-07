using System.ComponentModel.DataAnnotations.Schema;

namespace FormBuilder.Models
{
    public class AttributeSchemaOptionSetValue
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
