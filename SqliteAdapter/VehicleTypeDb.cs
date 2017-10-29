using System.ComponentModel.DataAnnotations;

namespace SqliteAdapter
{
    public class VehicleTypeDb
    {
        [Key]
        public int VehicleTypeId { get; set; }
        public string VehicleType { get; set; }
    }
}