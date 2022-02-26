using Microsoft.EntityFrameworkCore;
using Practica2_JLLR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practica2_JLLR.Context
{
    public class Practica2BdContext:DbContext
    {
        public Practica2BdContext(DbContextOptions<Practica2BdContext> options): base
            (options)
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseAssigment> CourseAssigments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment>OfficeAssignments { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
