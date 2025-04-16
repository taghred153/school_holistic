using Microsoft.EntityFrameworkCore;
using school_holistic.Models;

namespace school_holistic
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Laptop> Laptops { get; set;}
        public DbSet<Student> Students { get; set; }
    }
}
