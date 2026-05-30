using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string Location { get; set; }  
        
        public string phoneNumber { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();

        public virtual ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();

    }
}
