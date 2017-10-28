namespace RnvRestApi.DomainDtos
{
    public class StationDto
    {
        public string Name { get; set; }
        public StationId StationId { get; set; }
        public GeoLocation GeoLocation { get; set; }
    }
}