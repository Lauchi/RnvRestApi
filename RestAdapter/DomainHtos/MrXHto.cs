using System.Collections.Generic;
using System.Linq;
using Domain;

namespace RestAdapter.DomainHtos
{
    public class MrXHto : PlayerHto
    {
        public MrXHto(MrX mrX) : base(mrX)
        {
            Id = mrX.MrXId.Id;
            LocationsMadePublic = mrX.OpenMoves.Select(move => new MoveHto(move.MovedToStation.StationId.Id,
                move.Type.ToString(), move.MovedToStation.Name, move.MovedToStation.GeoLocation));
            UsedVehicles = mrX.UsedVehicles.Select(vehicle => vehicle.ToString());

            LastKnownLocation = mrX.LastKnownStation == Station.NullStation ? null : new StationHto(mrX.LastKnownStation);
        }

        public StationHto LastKnownLocation { get; }
        public IEnumerable<MoveHto> LocationsMadePublic { get; }
        public IEnumerable<string> UsedVehicles { get; }
    }
}