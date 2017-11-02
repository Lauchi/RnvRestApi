using Domain;

namespace RestAdapter.DomainHtos
{
    public class MoveHto
    {
        public MoveHto(string movedToStationId, string vehicleType, string name, GeoLocation geoLocation)
        {
            MovedToStationId = movedToStationId;
            VehicleType = vehicleType;
            Name = name;
            GeoLocation = geoLocation;
        }

        public string Name { get; }
        public GeoLocation GeoLocation { get; }
        public string MovedToStationId { get; }
        public string VehicleType { get; }
    }
}