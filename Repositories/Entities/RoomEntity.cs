using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace campus_api.Repositories.Entities
{
    [Table("Rooms")]
    public class RoomEntity
    {
        public int RoomID { get; set; }
        public Guid RoomKey { get; set; }
        public string Name { get; set; }
    }
}