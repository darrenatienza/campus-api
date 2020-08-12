using System.Collections.Generic;
using campus_api.Repositories.Entities;
using campus_api.Services.Mappers;
using CampusISApi.Model;

namespace campus_api.Services.IMappingService
{
    public interface IRoomMappingService : IMapper<Room, RoomEntity>, IMapper<RoomEntity, Room>, IMapper<IEnumerable<RoomEntity>, IEnumerable<Room>>
    {

    }
}