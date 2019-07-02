using Microsoft.EntityFrameworkCore;
using Repository.Pattern.EF.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace WPF.Model
{
    public class UniversityContext : DataContext
    {
        public UniversityContext(DbContextOptions options) : base(options) { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}
