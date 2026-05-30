using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public int totaldegree { get; set; }
        public int minimumdegree { get; set; }
        public List<string> Tobics  { get; set; } 

        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();

        public virtual ICollection <CourseInstructor> CourseInstructors { get; set; } = new HashSet<CourseInstructor>();
    }
}
