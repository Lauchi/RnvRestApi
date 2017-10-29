using System.Collections.Generic;
using RnvRestApi.Domain.ValueTypes.Ids;
using RnvRestApi.DomainDtos;

namespace RnvRestApi.Domain
{
    public class PoliceOfficer : Player
    {
        public PoliceOfficerId PoliceOfficerId { get; }
        public IEnumerable<StationDto> drivenLocations { get; }
        public IEnumerable<VehicelType> usedVehicles { get; }

        public PoliceOfficer(Tickets tickets) : base(tickets)
        {
        }
    }
}