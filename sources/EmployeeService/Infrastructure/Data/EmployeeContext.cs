using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class EmployeeContext : DbContext
    {
        private readonly EmployeeContext _context;

        public EmployeeContext(EmployeeContext context)
        {
            _context = context;
        }
        public DbSet<Employee> Employee { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Employee>()
           .Property(p => p.MiddleName)
           .HasMaxLength(50);

            modelBuilder.Entity<Employee>()
           .Property(p => p.LastName)
           .IsRequired()
           .HasMaxLength(50);

            modelBuilder.Entity<Employee>()
                .Property(p => p.Salary)
                .HasPrecision(9, 2)
                .HasAnnotation("MaxLength", 1000000);

        }
    }
}
