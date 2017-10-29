namespace SqliteAdapter
{
    public class MovementsDb
    {
        public string MovementId { get; set; }
        public string FromStationId { get; set; }
        public string ToStationId { get; set; }
        public int VehicleTypeId { get; set; }
        public VehicleTypeDb VehicleType { get; set; }
    }
}