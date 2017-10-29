using System.Collections.Generic;
using RestAdapter.Ids;

namespace RnvRestApi.Domain
{
    public class PoliceOfficer : Player
    {
        public PoliceOfficerId PoliceOfficerId { get; }
        public IEnumerable<Station> drivenLocations { get; }
        public IEnumerable<VehicelType> usedVehicles { get; }

        public PoliceOfficer(Tickets tickets) : base(tickets)
        {
        }
    }
}