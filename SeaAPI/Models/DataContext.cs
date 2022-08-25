using Microsoft.EntityFrameworkCore;
using SeaAPI.Models;

namespace SeaAPI.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {
        }
        public DbSet<BookingModel> BookingModel { get; set; } = null!;
    }
}
