using System.Collections.Generic;
using RnvRestApi.Domain.ValueTypes.Ids;
using RnvRestApi.DomainDtos;

namespace RnvRestApi.Domain
{
    public class Gangster
    {
        public GangsterId GangsterId { get; }
        public IEnumerable<StationDto> showedLocations { get; }
        public IEnumerable<VehicelType> usedVehicles { get; }
        public TicketPool TicketPool { get; }
    }
}