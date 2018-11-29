using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace dnevnik.Models
{
    public class DnevnikContext: DbContext
    {
        public DnevnikContext(string connectionString)
        {
            Database.Connection.ConnectionString = connectionString; 
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Shool> Shools { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
    }
}