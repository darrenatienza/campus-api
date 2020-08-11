
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusISApi.Controllers;
using CampusISApi.Model;
using CampusISApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;
using System.Net.Http.Formatting;
using System.Text.Json;
using Newtonsoft.Json;

namespace CampusISApi.Test.IntegrationTest
{

    public class RoomControllerTest : BaseHttpTest
    {
        public class ReadAllAsync : RoomControllerTest
        {
            private IEnumerable<Room> Rooms => new Room[] {
                new Room { Name = "My room" },
                new Room { Name = "Your room" },
                new Room { Name = "His room" }
            };

            protected override void ConfigureServices(IServiceCollection services)
            {
                services.AddSingleton(Rooms);
            }

            [Fact]
            public async Task Should_return_the_default_rooms()
            {
                // Arrange
                var expectedNumberOfRooms = Rooms.Count();

                // Act
                var result = await Client.GetAsync("v1/rooms");

                // Assert
                result.EnsureSuccessStatusCode();
                var rs = await result.Content.ReadAsStringAsync();
                var rooms = JsonConvert.DeserializeObject<Room[]>(rs);
                Assert.NotNull(rooms);
                Assert.Equal(expectedNumberOfRooms, rooms.Length);
                Assert.Collection(rooms,
                    clan => Assert.Equal(Rooms.ElementAt(0).Name, rooms[0].Name),
                    clan => Assert.Equal(Rooms.ElementAt(1).Name, rooms[1].Name),
                    clan => Assert.Equal(Rooms.ElementAt(2).Name, rooms[2].Name)
                );
            }
        }
    }
}