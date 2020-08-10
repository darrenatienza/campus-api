using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusISApi.Model;

namespace CampusISApi.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly List<Room> _rooms;
        public RoomRepository(IEnumerable<Room> rooms)
        {
            if (rooms == null) { throw new ArgumentNullException(nameof(rooms)); }
            _rooms = new List<Room>(rooms);
        }
        public Task<Room> CreateAsync(Room room)
        {
            throw new System.NotSupportedException();
        }

        public Task<Room> DeleteAsync(string roomName)
        {
            throw new System.NotSupportedException();
        }

        public Task<IEnumerable<Room>> ReadAllAsync()
        {
            return Task.FromResult(_rooms.AsEnumerable());
        }

        public Task<Room> ReadOneAsync(string roomName)
        {
            var room = _rooms.FirstOrDefault(r => r.Name == roomName);
            return Task.FromResult(room);
        }

        public Task<Room> UpdateAsync(Room room)
        {
            throw new System.NotSupportedException();
        }
    }
}