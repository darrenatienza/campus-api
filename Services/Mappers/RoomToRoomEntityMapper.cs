using campus_api.Repositories.Entities;
using CampusISApi.Model;

namespace campus_api.Services.Mappers
{
    public class RoomToRoomEntityMapper : IMapper<Room, RoomEntity>
    {
        public RoomEntity Map(Room room)
        {
            var entity = new RoomEntity
            {
                RoomID = room.RoomID,
                RoomKey = room.RoomKey,
                Name = room.Name
            };
            return entity;
        }
    }
}