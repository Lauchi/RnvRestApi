using System.ComponentModel.DataAnnotations;

namespace SqliteAdapter.Model
{
    public class MovementsDb
    {
        [Key]
        public string MovementId { get; set; }
        public string FromStationId { get; set; }
        public string ToStationId { get; set; }

        public string VehicleTypeId { get; set; }
        public VehicleTypeDb VehicleType { get; set; }
    }
}