using System.Collections.Generic;
using Domain.ValueTypes.Ids;

namespace RestAdapter.DomainHtos
{
    public class MrXHto
    {
        public MrXId MrXId { get; }
        public IEnumerable<StationId> showedLocations { get; }
        public IEnumerable<VehicelTypeHto> usedVehicles { get; }
        public TicketPoolId TicketPoolId { get; }
    }
}