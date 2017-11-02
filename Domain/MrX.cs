using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Domain.Validation;
using Domain.ValueTypes;
using Domain.ValueTypes.Ids;

namespace Domain
{
    public class MrX : Player
    {
        public static MrX NullValue { get; } = new MrX(new MrXId(new Guid().ToString()), "NaN");

        public IEnumerable<Move> OpenMoves { get; } = new Collection<Move>();
        public IEnumerable<VehicelType> UsedVehicles { get; } = new Collection<VehicelType>();

        public MrXId MrXId { get; }
        public event Action MrxDeleted;

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
            throw new NotImplementedException();
        }
    }
}