using System.Collections.Generic;
using System.Linq;
using Domain;

namespace RestAdapter.DomainHtos
{
    public class PoliceOfficerHto : PlayerHto
    {
        public PoliceOfficerHto(PoliceOfficer policeOfficer) : base(policeOfficer)
        {
            Id = policeOfficer.PoliceOfficerId.Id;
            VisitedLocations = policeOfficer.MoveHistory.Select(move => new MoveHto(move.MovedToStation.StationId.Id,
                move.Type.ToString(), move.MovedToStation.Name, move.MovedToStation.GeoLocation));
            CurrentLocation = new StationHto(policeOfficer.CurrentStation);
        }

        public StationHto CurrentLocation { get; }
        public IEnumerable<MoveHto> VisitedLocations { get; }
    }
}