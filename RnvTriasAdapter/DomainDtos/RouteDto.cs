using System.Collections.Generic;

namespace RnvTriasAdapter.DomainDtos
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