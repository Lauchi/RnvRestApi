using System.Collections.Generic;
using System.Linq;
using Domain;

namespace RestAdapter.DomainHtos
{
    public class MrXHto : PlayerHto
    {
        public MrXHto(string name) : base(name){}

        public MrXHto(MrX mrX) : base(mrX)
        {
            Id = mrX.MrXId.Id;
            LocationsMadePublic = mrX.VisitedStations.Select(station => station.Id.Id);
            UsedVehicles = mrX.usedVehicles.Select(vehicle => vehicle.ToString());
        }

        public IEnumerable<string> LocationsMadePublic { get; }
        public IEnumerable<string> UsedVehicles { get; }
    }
}