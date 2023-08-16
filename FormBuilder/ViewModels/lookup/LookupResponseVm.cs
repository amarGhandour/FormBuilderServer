namespace FormBuilder.ViewModels.lookup
{
    public class LookupResponseVm
    {
        public Guid LookupId { get; set; }

        public string LookFor { get; set; }

        public Guid LookForId { get; set; }

        public ICollection<string> Views { get; set; } = new HashSet<string>();
    }
}
