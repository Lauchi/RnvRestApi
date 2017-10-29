using System.Collections.Generic;
using RnvRestApi.Domain;
using RnvTriasAdapter.DomainDtos;

namespace RnvRestApi.DomainHtos
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