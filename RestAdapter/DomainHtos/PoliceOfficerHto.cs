using System.Collections.Generic;
using Domain.ValueTypes.Ids;

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