using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Contexts
{
    public class MyAppDbConext : IdentityDbContext<ApplicationUser>
    {
        public MyAppDbConext(DbContextOptions<MyAppDbConext> options) : base(options)
        {
        }
        //override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=MyITItRainingProj;Trusted_connection = true ; Encrypt = false");
        //}
       override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });


                modelBuilder.Entity<CourseInstructor>()
                    .HasKey(ci => new { ci.CourseId, ci.InstructorId });
           
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Student> Students { get; set; } 
        public DbSet <Course> Courses { get; set; }
        public DbSet <Department> Departments { get; set; }
        public DbSet <Instructor> Instructors { get; set; }
         public DbSet <StudentCourse> StudentCourses { get; set; }
        public DbSet <CourseInstructor> CourseInstructors { get; set; }


    }
}
