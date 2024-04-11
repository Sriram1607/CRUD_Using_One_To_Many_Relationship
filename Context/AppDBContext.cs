using CRUD_Using_One_To_Many_Relationship.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Using_One_To_Many_Relationship.Context
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options) 
        { 
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
              modelBuilder.Entity<Student>()
             .HasOne(s => s.Department)
             .WithMany(d => d.Students)
             .HasForeignKey(s => s.DepartmentId);
        }

        public DbSet<Student> Students { get; set; }    
        public DbSet<Department> Departments { get; set; }
    }
}
