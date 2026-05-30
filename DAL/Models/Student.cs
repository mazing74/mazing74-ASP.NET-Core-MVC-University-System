using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int ssn { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        [MaxLength(50, ErrorMessage = "Max Length Is 50 Chars")]
        [MinLength(5, ErrorMessage = "Min Length Is 5 Chars")]
        public string name { get; set; }

        [EmailAddress]

        public string email { get; set; }

        public int phone { get; set; }

        [RegularExpression("^(\\d+)\\s+([A-Za-z0-9\\s,.-]+),\\s*([A-Za-z\\s]+),\\s*([A-Z]{2})\\s+(\\d{5}(?:-\\d{4})?)$",
    ErrorMessage = "Addres Must Be Like: 789 Oak Blvd, Chicago, IL 60601")]
        public string address { get; set; }

        public string? image { get; set; }
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();



    }
}
