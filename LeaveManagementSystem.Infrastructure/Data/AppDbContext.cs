using Microsoft.EntityFrameworkCore;

using LeaveManagementSystem.Domain.Entities;
using LeaveManagementSystem.Domain;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration des relations
            modelBuilder.Entity<LeaveRequest>()
                .HasOne(lr => lr.Employee)
                .WithMany(e => e.LeaveRequests)
                .HasForeignKey(lr => lr.EmployeeId);

            // Seed des données initiales
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FullName = "Alice Dupont", Department = "IT", JoiningDate = new DateTime(2020, 1, 1) },
                new Employee { Id = 2, FullName = "Bob Martin", Department = "HR", JoiningDate = new DateTime(2019, 5, 15) }
            );
        }
    }
}