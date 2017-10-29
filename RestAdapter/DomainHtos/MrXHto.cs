using System.Collections.Generic;
using RnvRestApi.Domain;
using RnvRestApi.Domain.ValueTypes.Ids;
using RnvTriasAdapter.DomainDtos;

namespace RestAdapter.DomainHtos
{
    public class MrXHto
    {
        public MrXId MrXId { get; }
        public IEnumerable<StationId> showedLocations { get; }
        public IEnumerable<VehicelType> usedVehicles { get; }
        public TicketPoolId TicketPoolId { get; }
    }
}