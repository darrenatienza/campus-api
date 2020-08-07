using System.Collections.Generic;
using System.Threading.Tasks;
using CampusISApi.Model;

namespace CampusISApi.Services
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> ReadAllAsync();
        Task<Room> ReadOneAsync(string roomName);
        Task<bool> IsRoomExistsAsync(string roomName);
        Task<Room> CreateAsync(Room room);
        Task<Room> UpdateAsync(Room room);
        Task<Room> DeleteAsync(string roomName);
    }
}