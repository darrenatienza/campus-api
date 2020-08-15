

using CampusISApi.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace CampusISApi.Core
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Room> Rooms { get; set; }
    }
}