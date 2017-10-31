using System;
using Domain.Validation;
using Domain.ValueTypes.Ids;

namespace Domain
{
    public class PoliceOfficer : Player
    {
        public event Action<PoliceOfficer> PoliceOfficerDeleted;
        public PoliceOfficerId PoliceOfficerId { get; }

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
    }
}