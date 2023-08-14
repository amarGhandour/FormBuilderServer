using FormBuilder.Models.Tables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FormBuilder.ViewModels.Employee
{
    public class EmployeeRequestVM
    {
        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public decimal Salary { get; set; }

        public DateTime StartDate { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        public int Gender { get; set; }

        public int SocialStatus { get; set; }

        public string Notes { get; set; }
    }
}
