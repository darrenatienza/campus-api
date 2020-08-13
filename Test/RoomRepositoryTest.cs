using System;
using System.Threading.Tasks;
using campus_api.Repositories.Entities;
using campus_api.Services.IMappingService;
using CampusISApi.Model;
using CampusISApi.Repositories;
using Moq;
using Xunit;

namespace CampusISApi.Test
{
    public class RoomRepositoryTest
    {
        protected RoomRepository RepositoryUnderTest { get; }


        protected Mock<IRoomMappingService> RoomMappingServiceMock { get; }
        protected Mock<DataContext> DataContextMock { get; }
        public RoomRepositoryTest()
        {

            RoomMappingServiceMock = new Mock<IRoomMappingService>();
            DataContextMock = new Mock<DataContext>();
            RepositoryUnderTest = new RoomRepository(
                RoomMappingServiceMock.Object,
                DataContextMock.Object
            );
        }
        public class ReadAllAsync : RoomRepositoryTest
        {
            [Fact]
            public async Task Should_map_ReadAll_and_return_the_expected_room()
            {
                // Arrange
                var entities = new RoomEntity[0];
                var expectedRoom = new Room[0];


                RoomMappingServiceMock
                    .Setup(x => x.Map(entities))
                    .Returns(expectedRoom)
                    .Verifiable();

                // Act
                var result = await RepositoryUnderTest.ReadAllAsync();
                // Assert
                RoomMappingServiceMock
                    .Verify(x => x.Map(entities), Times.Once);

                DataContextMock
                    .Verify(x => x.Rooms, Times.Once);

                Assert.Equal(expectedRoom, result);
            }
        }

        public class ReadOneAsync : RoomRepositoryTest
        {
            [Fact]
            public async Task Should_map_ReadOne_and_return_the_expected_ninja()
            {
                // Arrange
                var roomName = "My room";
               
                var entity = new RoomEntity();
                var expectedNinja = new Room();

                
                RoomMappingServiceMock
                    .Setup(x => x.Map(entity))
                    .Returns(expectedNinja)
                    .Verifiable();

                // Act
                var result = await RepositoryUnderTest.ReadOneAsync(roomName);

                // Assert
                RoomMappingServiceMock
                    .Verify(x => x.Map(entity), Times.Once);
            
                Assert.Same(expectedNinja, result);
            }

            [Fact]
            public async Task Should_return_null_if_the_clan_does_not_exist()
            {
                // Arrange
                var unexistingRoomName = "Unexisting room";

                // Act
                var result = await RepositoryUnderTest.ReadOneAsync(unexistingRoomName);

                // Assert
                Assert.Null(result);
            }
        }

        public class CreateAsync : RoomRepositoryTest
        {
            [Fact]
            public async Task Should_throw_a_NotSupportedException()
            {
                // Arrange, Act, Assert
                var exception = await Assert.ThrowsAsync<NotSupportedException>(() => RepositoryUnderTest.CreateAsync(null));
            }
        }

        public class UpdateAsync : RoomRepositoryTest
        {
            [Fact]
            public async Task Should_throw_a_NotSupportedException()
            {
                // Arrange, Act, Assert
                var exception = await Assert.ThrowsAsync<NotSupportedException>(() => RepositoryUnderTest.UpdateAsync(null));
            }
        }

        public class DeleteAsync : RoomRepositoryTest
        {
            [Fact]
            public async Task Should_throw_a_NotSupportedException()
            {
                // Arrange, Act, Assert
                var exception = await Assert.ThrowsAsync<NotSupportedException>(() => RepositoryUnderTest.DeleteAsync(null));
            }
        }
    }
}