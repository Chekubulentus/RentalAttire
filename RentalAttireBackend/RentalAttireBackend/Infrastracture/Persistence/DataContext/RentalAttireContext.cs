using Microsoft.EntityFrameworkCore;
using RentalAttireBackend.Domain.Entities;

namespace RentalAttireBackend.Infrastracture.Persistence.DataContext
{
    public class RentalAttireContext : DbContext
    {
        public RentalAttireContext(DbContextOptions<RentalAttireContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>(e =>
            {
                //Configuration
                e.HasKey(e => e.Id);
                e.Property(e => e.FirstName).HasMaxLength(200);
                e.Property(e => e.MiddleName).HasMaxLength(200);
                e.Property(e => e.LastName).HasMaxLength(200);
                e.Property(e => e.Age).IsRequired();
                e.Property(e => e.Gender).IsRequired();
                e.HasIndex(e => e.EmployeeCode).IsUnique();
                e.HasIndex(e => e.PhoneNumber).IsUnique();

                // User RS
                e.HasOne(e => e.User)
                .WithOne(u => u.Employee)
                .HasForeignKey<User>(u => u.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

                //Role RS
                e.HasOne(e => e.Role)
                .WithMany(r => r.Employees)
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<User>(e =>
            {
                e.HasIndex(u => u.Username).IsUnique();
                e.Property(u => u.EmployeeId).IsRequired();
                e.Property(u => u.HashedPassword).IsRequired();
            });

            modelBuilder.Entity<Role>(e =>
            {
                e.HasIndex(r => r.RoleCode).IsUnique();
                e.Property(r => r.RolePosition).IsRequired();
            });
        }
    }
}
