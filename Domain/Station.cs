using Domain.ValueTypes.Ids;

namespace Domain
{
    public class Station
    {
        public Station(StationId stationId, string name, GeoLocation geoLocation)
        {
            StationId = stationId;
            Name = name;
            GeoLocation = geoLocation;
        }

        public StationId StationId { get; }
        public string Name { get; }
        public GeoLocation GeoLocation { get; }
    }
}