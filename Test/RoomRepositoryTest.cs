using System;
using System.Threading.Tasks;
using CampusISApi.Model;
using CampusISApi.Repositories;
using Xunit;

namespace CampusISApi.Test
{
    public class RoomRepositoryTest
    {
        protected RoomRepository RepositoryUnderTest { get; }
        protected Room[] Rooms { get; }
        public RoomRepositoryTest()
        {
            Rooms = new Room[]
            {
                new Room { Name = "My clan" },
                new Room { Name = "Your clan" },
                new Room { Name = "His clan" }
            };
            RepositoryUnderTest = new RoomRepository(Rooms);
        }
        public class ReadAllAsync : RoomRepositoryTest
        {
            [Fact]
            public async Task Should_return_all_clans()
            {
                // Act
                var result = await RepositoryUnderTest.ReadAllAsync();

                // Assert
                Assert.Collection(result,
                    room => Assert.Same(Rooms[0], room),
                    room => Assert.Same(Rooms[1], room),
                    room => Assert.Same(Rooms[2], room)
                );
            }
        }

        public class ReadOneAsync : RoomRepositoryTest
        {
            [Fact]
            public async Task Should_return_the_expected_room()
            {
                // Arrange
                var expectedRoom = Rooms[1];
                var expectedRoomName = expectedRoom.Name;

                // Act
                var result = await RepositoryUnderTest.ReadOneAsync(expectedRoomName);

                // Assert
                Assert.Same(expectedRoom, result);
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