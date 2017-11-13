using System;
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

        public static Station NullStation(GeoLocation geoLocation = null)
        {
            if (geoLocation == null) geoLocation = new GeoLocation(0, 0);
            return new Station(new StationId(new Guid().ToString()), "-", geoLocation);
        }
    }
}