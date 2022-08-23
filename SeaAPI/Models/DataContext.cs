using Microsoft.EntityFrameworkCore;

namespace SeaAPI.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {
        }

        public DbSet<SeaRouteModel> SeaRoutes { get; set; } = null!;
    }
}
