using System;
using System.Collections.Generic;
using campus_api.Repositories.Entities;
using campus_api.Services.IMappingService;
using campus_api.Services.Mappers;
using CampusISApi.Model;

namespace campus_api.Services.MappingService
{
    public class RoomMappingService : IRoomMappingService
    {
        private readonly IMapper<Room, RoomEntity> _roomToRoomEntityMapper;
        private readonly IMapper<RoomEntity, Room> _roomEntityToRoomMapper;
        private readonly IMapper<IEnumerable<RoomEntity>, IEnumerable<Room>> _roomEntityEnumerableToRoomMapper;

        public RoomMappingService(
            IMapper<Room, RoomEntity> ninjaToNinjaEntityMapper,
            IMapper<RoomEntity, Room> ninjaEntityToNinjaMapper,
            IMapper<IEnumerable<RoomEntity>, IEnumerable<Room>> ninjaEntityEnumerableToNinjaMapper
        )
        {
            _roomToRoomEntityMapper = ninjaToNinjaEntityMapper ?? throw new ArgumentNullException(nameof(ninjaToNinjaEntityMapper));
            _roomEntityToRoomMapper = ninjaEntityToNinjaMapper ?? throw new ArgumentNullException(nameof(ninjaEntityToNinjaMapper));
            _roomEntityEnumerableToRoomMapper = ninjaEntityEnumerableToNinjaMapper ?? throw new ArgumentNullException(nameof(ninjaEntityEnumerableToNinjaMapper));
        }

        public RoomEntity Map(Room entity)
        {
            return _roomToRoomEntityMapper.Map(entity);
        }

        public Room Map(RoomEntity entity)
        {
            return _roomEntityToRoomMapper.Map(entity);
        }

        public IEnumerable<Room> Map(IEnumerable<RoomEntity> entities)
        {
            return _roomEntityEnumerableToRoomMapper.Map(entities);
        }
    }
}