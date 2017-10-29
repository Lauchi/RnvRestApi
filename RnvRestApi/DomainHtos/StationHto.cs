using RnvTriasAdapter.DomainDtos;

namespace RnvRestApi.DomainHtos
{
    public class StationHto
    {
        public StationHto(StationId stationId, string name, GeoLocation geoLocation)
        {
            StationId = stationId;
            Name = name;
            GeoLocation = geoLocation;
        }

        public StationHto(StationDto stationDto)
        {
            StationId = stationDto.StationId;
            Name = stationDto.Name;
            GeoLocation = stationDto.GeoLocation;
        }

        public string Name { get; set; }
        public StationId StationId { get; set; }
        public GeoLocation GeoLocation { get; set; }
    }
}