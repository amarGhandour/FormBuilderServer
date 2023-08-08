using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using FormBuilder.Interfaces;

namespace FormBuilder.Models
{
    public class AttributeSchema: IEntityBase, ISoftDeletable
    {
        public int AttributeSchemaId { get; set; }

        [ForeignKey("EntitySchema")]
        public int EntitySchemaId { get; set; }

        public string LogicalName { get; set; }

        public string DisplayName { get; set; }

        public bool IsRequired { get; set; }

        //public bool IsActive { get; set; } = false;

        public bool IsSearchable { get; set; } = false;

        public int? MaxLen { get; set; }

        public int? MinLen { get; set; }

        [ForeignKey("AttributeType")]
        public int AttributeTypeId { get; set; }

        public AttributeType AttributeType { get; set; }

        public EntitySchema EntitySchema { get; set; }

        // public AttributeSchemaOptionSetType AttributeSchemaOptionSet { get; set; }

        [ForeignKey("OptionSetType")]
        public int? OptionSetTypeId { get; set; }
        public OptionSetType OptionSetType { get; set; }

        // public ICollection<AttributeSchemaOptionSetValue> AttributeTypesOptionSetValues { get; set; } = new HashSet<AttributeSchemaOptionSetValue>();



    }
}
