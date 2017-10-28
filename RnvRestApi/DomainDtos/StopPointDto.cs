using System;

namespace RnvRestApi.DomainDtos
{
    public class StopPointDto
    {
        public StationDto Station { get; set; }
        public DateTimeOffset Departure { get; set; }
    }
}