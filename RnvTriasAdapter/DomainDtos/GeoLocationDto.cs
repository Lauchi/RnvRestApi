namespace RnvTriasAdapter.DomainDtos
{
    public class GeoLocationDto
    {
        public GeoLocationDto(double longitude, double latitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}