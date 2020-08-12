using System;
using CampusISApi.Model;
using Xunit;

namespace campus_api.Services.Mappers
{
    public class RoomToRoomEntityMapperTest
    {
        protected RoomToRoomEntityMapper MapperUnderTest { get; }
        protected Guid uniqueID => Guid.Parse("692321ca-3f1b-4da3-8c42-0a2882e96b84");
        public RoomToRoomEntityMapperTest()
        {
            MapperUnderTest = new RoomToRoomEntityMapper();
        }
        public class Map : RoomToRoomEntityMapperTest
        {
            public void Should_return_a_well_formatted_entity()
            {
                //Arrange
                var room = new Room
                {
                    RoomID = 0,
                    RoomKey = uniqueID,
                    Name = "Some Name"
                };

                //Act
                var result = MapperUnderTest.Map(room);

                //Assert
                Assert.Equal(0, result.RoomID);
                Assert.Equal(uniqueID, result.RoomKey);
                Assert.Equal("Some Name", result.Name);


            }
        }
    }
}