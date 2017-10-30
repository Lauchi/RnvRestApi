using System.Collections.Generic;

namespace RestAdapter.DomainHtos
{
    public class MrXHto
    {
        public string Id { get; }
        public IEnumerable<string> locationsVisited { get; }
        public IEnumerable<VehicelTypeHto> usedVehicles { get; }
        public string TicketPoolId { get; }
    }
}