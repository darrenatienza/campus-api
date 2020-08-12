using System.Collections.Generic;
using campus_api.Repositories.Entities;
using campus_api.Services.Mappers;
using CampusISApi.Model;
using Moq;
using Xunit;

namespace campus_api.Services.MappingService
{
    public class RoomMappingServiceTest
    {
        protected RoomMappingService ServiceUnderTest { get; }
        protected Mock<IMapper<Room, RoomEntity>> RoomToRoomEntityMapperMock { get; }
        protected Mock<IMapper<RoomEntity, Room>> RoomEntityToRoomMapperMock { get; }
        protected Mock<IMapper<IEnumerable<RoomEntity>, IEnumerable<Room>>> RoomEntityEnumerableToRoomMapperMock { get; }

        public RoomMappingServiceTest()
        {
            RoomToRoomEntityMapperMock = new Mock<IMapper<Room, RoomEntity>>();
            RoomEntityToRoomMapperMock = new Mock<IMapper<RoomEntity, Room>>();
            RoomEntityEnumerableToRoomMapperMock = new Mock<IMapper<IEnumerable<RoomEntity>, IEnumerable<Room>>>();
            ServiceUnderTest = new RoomMappingService(
                RoomToRoomEntityMapperMock.Object,
                RoomEntityToRoomMapperMock.Object,
                RoomEntityEnumerableToRoomMapperMock.Object
            );
        }

        [Fact]
        public void Map_Room_to_RoomEntity_should_delegate_to_RoomToRoomEntityMapper()
        {
            // Arrange
            var Room = new Room();
            var expectedEntity = new RoomEntity();
            RoomToRoomEntityMapperMock
                .Setup(x => x.Map(Room))
                .Returns(expectedEntity);

            // Act
            var result = ServiceUnderTest.Map(Room);

            // Assert
            Assert.Same(expectedEntity, result);
        }

        [Fact]
        public void Map_RoomEntity_to_Room_should_delegate_to_RoomEntityToRoomMapper()
        {
            // Arrange
            var RoomEntity = new RoomEntity();
            var expectedRoom = new Room();
            RoomEntityToRoomMapperMock
                .Setup(x => x.Map(RoomEntity))
                .Returns(expectedRoom);

            // Act
            var result = ServiceUnderTest.Map(RoomEntity);

            // Assert
            Assert.Same(expectedRoom, result);
        }

        [Fact]
        public void Map_RoomEntityEnumerable_to_RoomEnumerable_should_delegate_to_RoomEntityEnumerableToRoomMapper()
        {
            // Arrange
            var RoomEntities = new List<RoomEntity>();
            var expectedRoom = new List<Room>();
            RoomEntityEnumerableToRoomMapperMock
                .Setup(x => x.Map(RoomEntities))
                .Returns(expectedRoom);

            // Act
            var result = ServiceUnderTest.Map(RoomEntities);

            // Assert
            Assert.Same(expectedRoom, result);
        }
    }
}