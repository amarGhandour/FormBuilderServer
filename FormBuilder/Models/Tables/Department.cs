namespace FormBuilder.Models.Tables
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Place { get; set; }

        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
