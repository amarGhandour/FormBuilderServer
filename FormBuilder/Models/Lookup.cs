using System.ComponentModel.DataAnnotations.Schema;

namespace FormBuilder.Models
{
    public class Lookup
    {
        public Guid LookupId { get; set; }

        public string relationShipName { get; set; }

        [ForeignKey("ParentTable")]
        public Guid ParentTableId { get; set; }

        public Guid ChildTableId { get; set; }

        public EntitySchema ParentTable { get; set; }

        //public EntitySchema ChildTable { get; set;}

    }
}
