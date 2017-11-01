using Domain;

namespace RestAdapter.DomainHtos
{
    public class StationHto
    {
        public StationHto(Station stationDto)
        {
            StationId = stationDto.StationId.Id;
            Name = stationDto.Name;
            GeoLocationDto = stationDto.GeoLocation;
        }

        public string Name { get; set; }
        public string StationId { get; set; }
        public GeoLocation GeoLocationDto { get; set; }
    }
}