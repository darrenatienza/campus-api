
using campus_api.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace CampusISApi.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<RoomEntity> Rooms { get; set; }
    }
}