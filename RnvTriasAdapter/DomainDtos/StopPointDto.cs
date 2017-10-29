using System;

namespace RnvTriasAdapter.DomainDtos
{
    public class StopPointDto
    {
        public StationDto Station { get; set; }
        public DateTimeOffset Departure { get; set; }
    }
}