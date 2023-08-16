using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.Pkcs;

namespace FormBuilder.Models.Tables
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public int Gender { get; set; } 
        public int SocialStatus { get; set; }
        public string Notes { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime StartDate { get; set; }
        public string Image { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

    }
}
