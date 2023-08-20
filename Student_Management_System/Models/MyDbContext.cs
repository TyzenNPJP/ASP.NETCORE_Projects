using Microsoft.EntityFrameworkCore;
using Student_Management_System.Models;
using Student_Management_System;

namespace Student_Management_System.Models
{
    public class MyDbContext : DbContext
    {
        // Constructor for DB
        public MyDbContext(DbContextOptions<MyDbContext> context) : base(context)
        {
            
        }

        public DbSet<SignUp> Signups { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Level> Level { get; set; }
        public DbSet<Course_1> Course_1 { get; set; } 
        public DbSet<StudentRegistration> StudentRegistration { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<AttendanceDetail> AttendanceDetail { get; set; }
    }
}
