using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using FormBuilder.Interfaces;

namespace FormBuilder.Models
{
    public class AttributeSchema: IEntityBase, ISoftDeletable
    {
        public Guid AttributeSchemaId { get; set; }

        public Guid EntitySchemaId { get; set; }

        public string LogicalName { get; set; }

        public string DisplayName { get; set; }

        public bool IsRequired { get; set; }

        public bool IsSearchable { get; set; } = false;

        public int? MaxLen { get; set; }

        public int? MinLen { get; set; }

        public Guid AttributeTypeId { get; set; }

        public AttributeType AttributeType { get; set; }

        public EntitySchema EntitySchema { get; set; }

        public Guid? OptionSetTypeId { get; set; }
        public OptionSetType OptionSetType { get; set; }

        [ForeignKey("Lookup")]
        public Guid? LookupId { get; set; }
        public Lookup Lookup { get; set; }

        [ForeignKey("GlobalSettings")]
        public Guid? UrlId { get; set; }
        public GlobalSettings GlobalSettings { get; set; }


    }
}
