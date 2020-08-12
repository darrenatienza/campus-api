using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using campus_api.Services.IMappingService;
using CampusISApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CampusISApi.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly IRoomMappingService _roomMappingService;
        private readonly DataContext _context;
        public RoomRepository(IRoomMappingService roomMappingService, DataContext context)
        {
            _roomMappingService = roomMappingService ?? throw new ArgumentNullException(nameof(roomMappingService));
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }
        public Task<Room> CreateAsync(Room room)
        {
            throw new System.NotSupportedException();
        }

        public Task<Room> DeleteAsync(string roomName)
        {
            throw new System.NotSupportedException();
        }

        public async Task<IEnumerable<Room>> ReadAllAsync()
        {
            var entities = await _context.Rooms.ToListAsync();
            var rooms = _roomMappingService.Map(entities.AsEnumerable());
            return rooms;
        }

        public async Task<Room> ReadOneAsync(string roomName)
        {
            var entity = await _context.Rooms.FirstOrDefaultAsync(x => x.Name == roomName);
            var rooms = _roomMappingService.Map(entity);
            return rooms;
        }

        public Task<Room> UpdateAsync(Room room)
        {
            throw new System.NotSupportedException();
        }
    }
}