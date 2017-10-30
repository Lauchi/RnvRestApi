using System;
using Domain.ValueTypes.Ids;

namespace Domain
{
    public class PoliceOfficer : Player
    {
        public PoliceOfficerId PoliceOfficerId { get; }

        public PoliceOfficer(string name) : base(name)
        {
            PoliceOfficerId = new PoliceOfficerId(Guid.NewGuid().ToString());
        }

        public PoliceOfficer(PoliceOfficerId id, string name) : base(name)
        {
            PoliceOfficerId = id;
        }
    }
}