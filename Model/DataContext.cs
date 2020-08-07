using Microsoft.EntityFrameworkCore;

namespace CampusISApi.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Room> Rooms { get; set; }
    }
}