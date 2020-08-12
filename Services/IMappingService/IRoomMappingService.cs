using System.Collections.Generic;
using campus_api.Repositories.Entities;
using CampusISApi.Model;

namespace campus_api.Services.IMappingService
{
    public interface IRoomMappingService
    {
        Room Map(RoomEntity entity);
        RoomEntity Map(Room room);
        IEnumerable<Room> Map(IEnumerable<RoomEntity> entity);
    }
}