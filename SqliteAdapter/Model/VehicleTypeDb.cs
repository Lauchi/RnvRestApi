using System.ComponentModel.DataAnnotations;

namespace SqliteAdapter.Model
{
    public class VehicleTypeDb
    {
        [Key]
        public string VehicleTypeId { get; set; }
        public string VehicleType { get; set; }
    }
}