using System.Collections.Generic;
using System.Threading.Tasks;
using CampusISApi.Model;

namespace CampusISApi.Repositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> ReadAllAsync();
        Task<Room> ReadOneAsync(string roomName);
        Task<Room> CreateAsync(Room room);
        Task<Room> UpdateAsync(Room room);
        Task<Room> DeleteAsync(string roomName);
    }
}