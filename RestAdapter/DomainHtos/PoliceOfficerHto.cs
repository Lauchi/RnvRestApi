using System.Collections.Generic;
using System.Linq;
using Domain;

namespace RestAdapter.DomainHtos
{
    public class PoliceOfficerHto : PlayerHto
    {
        public IEnumerable<string> VisitedLocations { get; }

        public PoliceOfficerHto(PoliceOfficer player) : base(player)
        {
            Id = player.PoliceOfficerId.Id;
            VisitedLocations = player.VisitedStations.Select(station => station.Id.Id);
        }
    }
}