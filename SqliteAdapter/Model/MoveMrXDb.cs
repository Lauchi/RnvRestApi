using System.ComponentModel.DataAnnotations;

namespace SqliteAdapter.Model
{
    public class MoveMrXDb
    {
        [Key]
        public int MoveId { get; set; }
        public string StationId { get; set; }
        public string VehicleType { get; set; }
    }
}