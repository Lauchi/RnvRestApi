using System.Collections.Generic;
using RnvTriasAdapter.DomainDtos;

namespace RestAdapter.DomainHtos
{
    public class RouteHto
    {
        public RouteHto()
        {
            StopPoints = new List<StopPointDto>();
        }
        public IEnumerable<StopPointDto> StopPoints { get; set; }
    }
}