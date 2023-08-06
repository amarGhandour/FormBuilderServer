﻿using System.ComponentModel.DataAnnotations.Schema;

namespace FormBuilder.Models
{
    public class AttributeSchema
    {
        public int AttributeSchemaId { get; set; }

        [ForeignKey("EntitySchema")]
        public int EntitySchemaId { get; set; }

        public string LogicalName { get; set; }

        public string DisplayName { get; set; }

        public bool IsRequired { get; set; }

        public int? MaxLen { get; set; }

        public int? MinLen { get; set; }

        [ForeignKey("AttributeType")]
        public int AttributeTypeId { get; set; }

        public AttributeType AttributeType { get; set; }

        EntitySchema EntitySchema { get; set; }

    }
}
