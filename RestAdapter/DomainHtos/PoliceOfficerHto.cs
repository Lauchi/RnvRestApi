using System.Collections.Generic;
using System.Linq;
using Domain;

namespace RestAdapter.DomainHtos
{
    public class PoliceOfficerHto : PlayerHto
    {
        public PoliceOfficerHto(PoliceOfficer player) : base(player)
        {
            Id = player.PoliceOfficerId.Id;
            VisitedLocations = player.MoveHistory.Select(move => new MoveHto(move.MovedToStation.StationId.Id,
                move.Type.ToString(), move.MovedToStation.Name, move.MovedToStation.GeoLocation));
        }

        public IEnumerable<MoveHto> VisitedLocations { get; }
    }
}