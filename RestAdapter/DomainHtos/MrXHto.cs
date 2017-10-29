using System.Collections.Generic;
using RestAdapter.Ids;
using RnvTriasAdapter.DomainDtos;

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