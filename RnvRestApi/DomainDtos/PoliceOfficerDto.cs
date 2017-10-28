using System.Collections.Generic;
using RnvRestApi.Domain;
using RnvRestApi.Domain.ValueTypes.Ids;

namespace RnvRestApi.DomainDtos
{
    public class PoliceOfficerDto
    {
        public PoliceOfficerId PoliceOfficerId { get; }
        public IEnumerable<StationId> drivenLocations { get; }
        public IEnumerable<VehicelType> usedVehicles { get; }
        public TicketPoolId TicketPoolId { get; }
    }
}