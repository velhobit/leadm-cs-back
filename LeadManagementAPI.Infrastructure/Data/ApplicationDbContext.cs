using Microsoft.EntityFrameworkCore;
using LeadManagementAPI.Domain.Entities;

namespace LeadManagementAPI.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

        public DbSet<Lead> Leads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Lead>()
                .Property(l => l.Price)
                .HasColumnType("decimal(18,2)") 
                .HasPrecision(18, 2);

            modelBuilder.Entity<Lead>()
                .Property(l => l.PriceToPay)
                .HasColumnType("decimal(18,2)") 
                .HasPrecision(18, 2);
        }
    }
}
