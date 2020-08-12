using System.Collections.Generic;
using campus_api.Repositories.Entities;
using CampusISApi.Model;
using Moq;
using Xunit;

namespace campus_api.Services.Mappers.Test
{
    public class EnumerableMapperTest
    {
        public class Map : EnumerableMapperTest
        {
            public class RoomEntity2Room : Map
            {
                protected EnumerableMapper<RoomEntity, Room> MapperUnderTest { get; }
                protected Mock<IMapper<RoomEntity, Room>> RoomEntityToRoomMapperMock { get; }
                public RoomEntity2Room()
                {
                    RoomEntityToRoomMapperMock = new Mock<IMapper<RoomEntity, Room>>();
                    MapperUnderTest = new EnumerableMapper<RoomEntity, Room>(RoomEntityToRoomMapperMock.Object);
                }
                [Fact]
                public void Should_delegete_mapping_to_the_single_entity_mapper()
                {
                    //Arrange
                    var room1 = new RoomEntity();
                    var room2 = new RoomEntity();
                    var roomEntities = new List<RoomEntity> { room1, room2 };
                    RoomEntityToRoomMapperMock
                    .Setup(x => x.Map(It.IsAny<RoomEntity>()))
                    .Returns(new Room())
                    .Verifiable();
                    var result = MapperUnderTest.Map(roomEntities);

                    RoomEntityToRoomMapperMock.Verify(x => x.Map(room1), Times.Once);
                    RoomEntityToRoomMapperMock.Verify(x => x.Map(room2), Times.Once);

                }
            }

        }
    }
}