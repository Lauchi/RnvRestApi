using System;
using RnvRestApi.DomainDtos;

namespace RnvRestApi.Domain
{
    public class StopPointDto
    {
        public StationDto Station { get; set; }
        public DateTimeOffset Departure { get; set; }
    }
}