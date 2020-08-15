using System;

namespace CampusISApi.Core.Domain
{
    public class Room
    {
        public int RoomID { get; set; }
        public string Name { get; set; }
        public Guid RoomKey { get; internal set; }
    }


}