using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Transactions;
using Domain.Validation;
using Domain.ValueTypes;
using Domain.ValueTypes.Ids;

namespace Domain
{
    public class MrX : Player
    {
        public static MrX NullValue { get; } = new MrX(new MrXId(new Guid().ToString()), "NaN");

        public ICollection<Move> OpenMoves { get; } = new Collection<Move>();
        public ICollection<VehicelType> UsedVehicles { get; } = new Collection<VehicelType>();

        public MrXId MrXId { get; }
        public event Action MrxDeleted;
        public event Action<Move, MrX> MrxMoved;

        public MrX(MrXId mrXId, string name) : base(name)
        {
            MrXId = mrXId;
        }

        public MrX(string name) : base(name)
        {
            MrXId = new MrXId(Guid.NewGuid().ToString());
        }

        public DomainValidationResult Delete()
        {
            MrxDeleted?.Invoke();
            return DomainValidationResult.OkResult();
        }

        public override DomainValidationResult Move(Station station, VehicelType vehicelType)
        {
            var move = new Move(station, vehicelType);
            MoveHistory.Add(move);
            CurrentStationHidden = station;
            if (MoveHistory.Count % 5 == 0)
            {
                OpenMoves.Add(move);
                LastKnownStation = station;
            }

            UsedVehicles.Add(vehicelType);
            MrxMoved?.Invoke(move, this);
            return DomainValidationResult.OkResult();
        }

        public Station LastKnownStation { get; private set; }

        public Station CurrentStationHidden { get; private set; }
    }
}