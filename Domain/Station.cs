using Domain.ValueTypes.Ids;

namespace Domain
{
    public class Station
    {
        public StationId Id { get; }
        public string Name { get; }
        public GeoLocation GeoLocation { get; }
    }
}