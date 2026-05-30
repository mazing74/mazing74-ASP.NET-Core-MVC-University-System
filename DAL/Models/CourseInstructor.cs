using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class CourseInstructor
    {
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }
        public int hours { get; set; }

    }
}
