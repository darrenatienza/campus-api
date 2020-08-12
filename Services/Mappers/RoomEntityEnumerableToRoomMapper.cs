using System.Collections;
using System.Collections.Generic;
using campus_api.Repositories.Entities;
using CampusISApi.Model;

namespace campus_api.Services.Mappers
{
    public class RoomEntityEnumerableToRoomMapper : IMapper<IEnumerable<RoomEntity>, IEnumerable<Room>>
    {
        public IEnumerable<Room> Map(IEnumerable<RoomEntity> entity)
        {
            throw new System.NotImplementedException();
        }
    }
}