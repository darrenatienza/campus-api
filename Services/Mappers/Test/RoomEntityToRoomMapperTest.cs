using System;
using campus_api.Repositories.Entities;
using Xunit;

namespace campus_api.Services.Mappers.Test
{
    public class RoomEntityToRoomMapperTest
    {
        protected Guid uniqueID => Guid.Parse("692321ca-3f1b-4da3-8c42-0a2882e96b84");
        protected RoomEntityToRoomMapper MapperUnderTest { get; }

        public RoomEntityToRoomMapperTest()
        {
            MapperUnderTest = new RoomEntityToRoomMapper();
        }
        public class Map : RoomEntityToRoomMapperTest
        {
            [Fact]
            public void Should_return_a_well_formatted_room()
            {
                //Arrange
                var entity = new RoomEntity
                {
                    RoomID = 0,
                    RoomKey = uniqueID,
                    Name = "Some Fake Name"
                };

                //Act
                var result = MapperUnderTest.Map(entity);

                //Assert
                Assert.Equal(0, result.RoomID);
                Assert.Equal(uniqueID, result.RoomKey);
                Assert.Equal("Some Fake Name", result.Name);
            }
        }
    }
}