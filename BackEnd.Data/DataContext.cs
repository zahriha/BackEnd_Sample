using BackEnd.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace BackEnd.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions options) : base(options)
        {


        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=BackEnd_Zahri;Integrated Security=SSPI");
           
        }

    }
}
