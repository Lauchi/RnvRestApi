using System.Collections.Generic;
using System.Linq;
using Domain;

namespace RestAdapter.DomainHtos
{
    public class PoliceOfficerHto : PlayerHto
    {
        public IEnumerable<MoveHto> VisitedLocations { get; }

        public PoliceOfficerHto(PoliceOfficer player) : base(player)
        {
            Id = player.PoliceOfficerId.Id;
            VisitedLocations = player.MoveHistory.Select(move => new MoveHto(move.MovedToStation.StationId.Id, move.Type.ToString()));
        }
    }

    public class MoveHto
    {
        public MoveHto(string movedToStationId, string vehicleType)
        {
            MovedToStationId = movedToStationId;
            VehicleType = vehicleType;
        }

        public string MovedToStationId { get; }
        public string VehicleType { get; }
    }
}