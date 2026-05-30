using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string name { get; set; }

        [Range(18, 60)]
        public int age { get; set; }

        [Range(0, 1000000)]
        [DataType(DataType.Currency)]
        public decimal salary { get; set; }

        [Range(0, 100)]
        public int degree { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(200)]
        public string email { get; set; }

        [StringLength(500)]
        public string address { get; set; }

        [Phone]
        [StringLength(50)]
        public string phone { get; set; }
        [ForeignKey("Department")]

        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; } = new HashSet<CourseInstructor>();

    }
}
