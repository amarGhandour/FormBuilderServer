using System.ComponentModel.DataAnnotations.Schema;
using FormBuilder.Interfaces;

namespace FormBuilder.Models
{
    public class AttributeSchemaOptionSetType: IEntityBase
    {
        public int Id { get; set; }

        [ForeignKey("AttributeSchema")]
        public int AttributeSchemaId { get; set; }

        [ForeignKey("OptionSetType")]
        public int OptionSetTypeId { get; set; }
        public OptionSetType OptionSetType { get; set; }
        public AttributeSchema AttributeSchema { get; set; }

    }
}
