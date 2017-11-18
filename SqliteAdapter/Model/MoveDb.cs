using System.ComponentModel.DataAnnotations;

namespace SqliteAdapter.Model
{
    public class MoveDb
    {
        [Key]
        public int MoveId { get; set; }
        public StationDb Station { get; set; }
        public string VehicleType { get; set; }
    }
}