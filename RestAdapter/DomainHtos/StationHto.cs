using RnvTriasAdapter.DomainDtos;

namespace RestAdapter.DomainHtos
{
    public class StationHto
    {
        public StationHto(StationDto stationDto)
        {
            StationId = stationDto.StationId.Id;
            Name = stationDto.Name;
            GeoLocationDto = stationDto.GeoLocationDto;
        }

        public string Name { get; set; }
        public string StationId { get; set; }
        public GeoLocationDto GeoLocationDto { get; set; }
    }
}