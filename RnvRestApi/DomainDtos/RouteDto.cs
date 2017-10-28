using System.Collections.Generic;
using RnvRestApi.Domain;

namespace RnvRestApi.DomainDtos
{
    public class RouteDto
    {
        public RouteDto()
        {
            StopPoints = new List<StopPointDto>();
        }
        public IEnumerable<StopPointDto> StopPoints { get; set; }
    }
}