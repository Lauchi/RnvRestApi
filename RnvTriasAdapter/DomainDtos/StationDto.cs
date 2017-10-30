using Domain.ValueTypes.Ids;

namespace RnvTriasAdapter.DomainDtos
{
    public class StationDto
    {
        public StationDto(StationId stationId, string name, GeoLocationDto geoLocationDto)
        {
            StationId = stationId;
            Name = name;
            GeoLocationDto = geoLocationDto;
        }
        public string Name { get; set; }
        public StationId StationId { get; set; }
        public GeoLocationDto GeoLocationDto { get; set; }
    }
}