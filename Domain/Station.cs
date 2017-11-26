using System;
using Domain.ValueTypes.Ids;

namespace Domain
{
    public class Station
    {
        public Station(StationId stationId, string name, GeoLocation geoLocation, VehicelType type)
        {
            StationId = stationId;
            Name = name;
            GeoLocation = geoLocation;
            Type = type;
        }

        public StationId StationId { get; }
        public string Name { get; }
        public GeoLocation GeoLocation { get; }
        public VehicelType Type { get; set; }

        public static Station NullStation(GeoLocation geoLocation = null)
        {
            if (geoLocation == null) geoLocation = new GeoLocation(0, 0);
            return new Station(new StationId(Guid.NewGuid().ToString()), "-", geoLocation, VehicelType.NotSetYet);
        }
    }
}