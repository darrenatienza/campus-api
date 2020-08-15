
using Campus.Services.IServices;
using CampusISApi.Core;
using CampusISApi.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campus.Services.Services
{
    public class RoomServices : IRoomServices
    {
        public readonly DataContext _context;
        public RoomServices(DataContext context)
        {
            _context = context ?? throw new NotImplementedException(nameof(context));
        }

        public Task<Room> Add(Room room)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int roomID, Room room)
        {
            throw new NotImplementedException();
        }

        public Task<Room> Edit(int roomID, Room room)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();
            return rooms.AsEnumerable();

        }

        public async Task<Room> GetRoom(int roomID)
        {
            return await _context.Rooms.FindAsync(roomID);
        }

        public async Task<Room> GetRoom(Guid roomKey)
        {
            return await _context.Rooms.FirstOrDefaultAsync(x => x.RoomKey == roomKey);
        }
    }
}
