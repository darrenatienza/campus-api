using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CampusISApi.Model;
using CampusISApi.Repositories;

namespace CampusISApi.Services
{
    public class RoomService : IRoomService
    {
        private IRoomRepository _roomRepository;
        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
        }
        public Task<Room> CreateAsync(Room room)
        {
            throw new NotSupportedException();
        }

        public Task<Room> DeleteAsync(string roomName)
        {
            throw new NotSupportedException();
        }

        public async Task<bool> IsRoomExistsAsync(string roomName)
        {
            var clan = await _roomRepository.ReadOneAsync(roomName);
            return clan
                != null;
        }

        public Task<IEnumerable<Room>> ReadAllAsync()
        {
            return _roomRepository.ReadAllAsync();
        }

        public Task<Room> ReadOneAsync(string roomName)
        {
            return _roomRepository.ReadOneAsync(roomName);
        }

        public Task<Room> UpdateAsync(Room room)
        {
            throw new NotSupportedException();
        }
    }
}