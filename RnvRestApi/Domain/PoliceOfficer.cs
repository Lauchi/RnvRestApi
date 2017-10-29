using System.Collections.Generic;
using RnvRestApi.Domain.ValueTypes.Ids;
using RnvRestApi.DomainHtos;

namespace RnvRestApi.Domain
{
    public class PoliceOfficer : Player
    {
        public PoliceOfficerId PoliceOfficerId { get; }
        public IEnumerable<StationHto> drivenLocations { get; }
        public IEnumerable<VehicelType> usedVehicles { get; }

        public PoliceOfficer(Tickets tickets) : base(tickets)
        {
        }
    }
}