
using CampusISApi.Core.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campus.Services.IServices
{
    public interface IRoomServices
    {
        Task<IEnumerable<Room>> GetAllRooms();
        Task<Room> GetRoom(int roomID);
        Task<Room> GetRoom(Guid roomKey);
        Task<Room> Add(Room room);
        Task<Room> Edit(int roomID, Room room);

        Task<bool> Delete(int roomID, Room room);

    }
}
