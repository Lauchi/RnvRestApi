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
            LocationsMadePublic = mrX.OpenMoves.Select(move => new MoveHto(move.MovedToStation.StationId.Id, move.Type.ToString()));
            UsedVehicles = mrX.UsedVehicles.Select(vehicle => vehicle.ToString());
        }

        public IEnumerable<MoveHto> LocationsMadePublic { get; }
        public IEnumerable<string> UsedVehicles { get; }
    }
}