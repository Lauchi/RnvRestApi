using System;
using Domain.Validation;
using Domain.ValueTypes;
using Domain.ValueTypes.Ids;

namespace Domain
{
    public class PoliceOfficer : Player
    {
        public static event Action<PoliceOfficer> PoliceOfficerDeleted;
        public static event Action<PoliceOfficer> PoliceOfficerMoved;
        public PoliceOfficerId PoliceOfficerId { get; }
        public Station CurrentStation { get; protected set; } = Station.NullStation;


        public PoliceOfficer(PoliceOfficerId id, string name) : base(name)
        {
            PoliceOfficerId = id;
        }

        public PoliceOfficer(string name) : base(name)
        {
            PoliceOfficerId = new PoliceOfficerId(Guid.NewGuid().ToString());
        }

        public DomainValidationResult Delete()
        {
            PoliceOfficerDeleted?.Invoke(this);
            return DomainValidationResult.OkResult();
        }

        public override DomainValidationResult Move(Station station, VehicelType vehicelType)
        {
            var move = new Move(station, vehicelType);
            MoveHistory.Add(move);
            CurrentStation = station;
            PoliceOfficerMoved?.Invoke(this);
            return DomainValidationResult.OkResult();
        }
    }
}