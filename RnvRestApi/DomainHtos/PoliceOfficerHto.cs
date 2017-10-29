using System.Collections.Generic;
using RnvRestApi.Domain;
using RnvRestApi.Domain.ValueTypes.Ids;
using RnvTriasAdapter.DomainDtos;

namespace RnvRestApi.DomainHtos
{
    public class PoliceOfficerHto
    {
        public PoliceOfficerId PoliceOfficerId { get; }
        public IEnumerable<StationId> drivenLocations { get; }
        public IEnumerable<VehicelType> usedVehicles { get; }
        public TicketPoolId TicketPoolId { get; }
    }
}