using FirstProject.Models;
using Microsoft.EntityFrameworkCore;
namespace FirstProject.Data
{
    public class PlanDataContext : DbContext
    {
        public PlanDataContext(DbContextOptions<PlanDataContext> options): base (options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
        public DbSet<Plan> Plans { get; set; }
    }
}
