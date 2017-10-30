using System.Collections.Generic;
using System.Linq;
using Domain;

namespace RestAdapter.DomainHtos
{
    public class PoliceOfficerHto : PlayerHto
    {
        public IEnumerable<string> VisitedLocations { get; }

        public PoliceOfficerHto(Player player) : base(player)
        {
            VisitedLocations = player.VisitedStations.Select(station => station.Id.Id);
        }
    }
}