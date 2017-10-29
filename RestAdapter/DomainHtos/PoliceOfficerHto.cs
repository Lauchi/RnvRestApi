using System.Collections.Generic;
using RestAdapter.Ids;
using RnvTriasAdapter.DomainDtos;

namespace RestAdapter.DomainHtos
{
    public class PoliceOfficerHto
    {
        public PoliceOfficerId PoliceOfficerId { get; }
        public IEnumerable<StationId> drivenLocations { get; }
        public IEnumerable<VehicelTypeHto> usedVehicles { get; }
        public TicketPoolId TicketPoolId { get; }
    }
}