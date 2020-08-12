using campus_api.Repositories.Entities;
using CampusISApi.Model;
using Moq;

namespace campus_api.Services.Mappers.Test
{
    public class RoomEntityEnumerableToRoomMapperTest
    {
        protected RoomEntityEnumerableToRoomMapper MapperUnderTest { get; }
        protected Mock<IMapper<RoomEntity, Room>> RoomEntityToRoomMapperMock { get; }
    }
}