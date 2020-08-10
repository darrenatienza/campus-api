
using CampusISApi.Controllers;
using CampusISApi.Model;
using CampusISApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CampusISApi.Test.IntegrationTest
{

    public class RoomControllerTest : BaseHttpTest
    {
        protected RoomsController ControllerUnderTest { get; }
        protected Mock<IRoomService> RoomServiceMock { get; }

        public RoomControllerTest()
        {
            RoomServiceMock = new Mock<IRoomService>(); // IClanService mock
            ControllerUnderTest = new RoomsController(RoomServiceMock.Object);
        }

        public class ReadAllAsync : RoomControllerTest
        {
            [Fact]
            public async void Should_return_OkObjectResult_with_rooms()
            {
                // Arrange
                var expectedRooms = new Room[]
                {
                    new Room { Name = "Test room 1" },
                    new Room { Name = "Test room 2" },
                    new Room { Name = "Test room 3" }
                };

                RoomServiceMock
                    .Setup(x => x.ReadAllAsync())
                    .ReturnsAsync(expectedRooms); // Mocked the ReadAllAsync() method

                // Act
                var result = await ControllerUnderTest.ReadAllAsync();

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(expectedRooms, okResult.Value);
            }
        }
    }
}