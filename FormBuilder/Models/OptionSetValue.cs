using FormBuilder.Controllers.Api;
using FormBuilder.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace FormBuilder.Models
{
    public class OptionSetValue : IEntityBase, ISoftDeletable
    {
        public int Id { get; set;}

        public string Value { get; set; }

        public string Name { get; set; }

        [ForeignKey("OptionSetType")]
        public int OptionSetTypeId { get; set; }

        public OptionSetType OptionSetType { get; set; }
    }
}
