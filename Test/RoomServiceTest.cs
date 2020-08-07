using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CampusISApi.Model;
using CampusISApi.Repositories;
using CampusISApi.Services;
using Moq;
using Xunit;

namespace CampusISApi.Test
{
    public class RoomServiceTest
    {
        protected RoomService ServiceUnderTest { get; }
        protected Mock<IRoomRepository> RoomRepositoryMock { get; }
        public RoomServiceTest()
        {
            RoomRepositoryMock = new Mock<IRoomRepository>();
            ServiceUnderTest = new RoomService(RoomRepositoryMock.Object);
        }

        public class ReadAllAsync : RoomServiceTest
        {
            [Fact]
            public async Task Should_return_all_Rooms()
            {
                // Arrange
                var expectedRooms = new ReadOnlyCollection<Room>(new List<Room>
                {
                    new Room { Name = "My Room" },
                    new Room { Name = "Your Room" },
                    new Room { Name = "His Room" }
                });
                RoomRepositoryMock
                        .Setup(x => x.ReadAllAsync())
                        .ReturnsAsync(expectedRooms);
                // Act
                var result = await ServiceUnderTest.ReadAllAsync();

                // Assert
                Assert.Same(expectedRooms, result);
            }
        }

        public class ReadOneAsync : RoomServiceTest
        {
            [Fact]
            public async Task Should_return_the_expected_Room()
            {
                // Arrange
                var roomName = "My Room";
                var expectedRoom = new Room { Name = roomName };
                RoomRepositoryMock
                        .Setup(x => x.ReadOneAsync(roomName))
                        .ReturnsAsync(expectedRoom);
                // Act
                var result = await ServiceUnderTest.ReadOneAsync(roomName);

                // Assert
                Assert.Same(expectedRoom, result);
            }

            [Fact]
            public async Task Should_return_null_if_the_Room_does_not_exist()
            {
                // Arrange
                var RoomName = "My Room";
                RoomRepositoryMock
                        .Setup(x => x.ReadOneAsync(RoomName))
                        .ReturnsAsync(default(Room));
                // Act
                var result = await ServiceUnderTest.ReadOneAsync(RoomName);

                // Assert
                Assert.Null(result);
            }
        }

        public class IsRoomExistsAsync : RoomServiceTest
        {
            [Fact]
            public async Task Should_return_true_if_the_Room_exist()
            {
                // Arrange
                var RoomName = "Your Room";
                RoomRepositoryMock
                        .Setup(x => x.ReadOneAsync(RoomName))
                        .ReturnsAsync(new Room());
                // Act
                var result = await ServiceUnderTest.IsRoomExistsAsync(RoomName);

                // Assert
                Assert.True(result);
            }
            [Fact]
            public async Task Should_return_false_if_the_Room_does_not_exist()
            {
                // Arrange
                var RoomName = "Unexisting Room";
                RoomRepositoryMock
                        .Setup(x => x.ReadOneAsync(RoomName))
                        .ReturnsAsync(default(Room));
                // Act
                var result = await ServiceUnderTest.IsRoomExistsAsync(RoomName);

                // Assert
                Assert.False(result);
            }
        }

        public class CreateAsync : RoomServiceTest
        {
            [Fact]
            public async Task Should_create_and_return_the_specified_Room()
            {
                // Arrange, Act, Assert
                var exception = await Assert.ThrowsAsync<NotSupportedException>(() => ServiceUnderTest.CreateAsync(null));
            }
        }

        public class UpdateAsync : RoomServiceTest
        {
            [Fact]
            public async Task Should_update_and_return_the_specified_Room()
            {
                // Arrange, Act, Assert
                var exception = await Assert.ThrowsAsync<NotSupportedException>(() => ServiceUnderTest.UpdateAsync(null));
            }
        }

        public class DeleteAsync : RoomServiceTest
        {
            [Fact]
            public async Task Should_delete_and_return_the_specified_Room()
            {
                // Arrange, Act, Assert
                var exception = await Assert.ThrowsAsync<NotSupportedException>(() => ServiceUnderTest.DeleteAsync(null));
            }
        }
    }
}