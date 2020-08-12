using campus_api.Repositories.Entities;
using CampusISApi.Model;

namespace campus_api.Services.Mappers
{

    public class RoomEntityToRoomMapper : IMapper<RoomEntity, Room>
    {
        public Room Map(RoomEntity entity)
        {
            var room = new Room
            {
                RoomID = entity.RoomID,
                RoomKey = entity.RoomKey,
                Name = entity.Name
            };
            return room;

        }
    }
}