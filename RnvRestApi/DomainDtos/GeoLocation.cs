namespace RnvRestApi.DomainDtos
{
    public class GeoLocation
    {
        public GeoLocation(double longitude, double latitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}