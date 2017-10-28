namespace RnvRestApi.DomainDtos
{
    public class StationDto
    {
        public StationDto(StationId stationId, string name, GeoLocation geoLocation)
        {
            StationId = stationId;
            Name = name;
            GeoLocation = geoLocation;
        }
        public string Name { get; set; }
        public StationId StationId { get; set; }
        public GeoLocation GeoLocation { get; set; }
    }
}