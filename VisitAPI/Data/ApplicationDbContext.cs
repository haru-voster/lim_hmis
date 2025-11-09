using Microsoft.EntityFrameworkCore;
using VisitAPI.Models;

namespace VisitAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<LabRequest> LabRequests { get; set; } = null!;
        public DbSet<LabTest> LabTests { get; set; } = null!;
    }
}
