using Microsoft.EntityFrameworkCore;
using VisitAPI.Models;

namespace VisitAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<LabRequest> LabRequests { get; set; } = null!;
        public DbSet<LabTest> LabTests { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LabRequest>()
                .HasMany(r => r.LabTests)
                .WithOne(t => t.LabRequest)
                .HasForeignKey(t => t.LabRequestId);
        }
    }
}
