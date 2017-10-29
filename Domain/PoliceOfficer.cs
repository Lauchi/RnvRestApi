using Domain.ValueTypes.Ids;

namespace Domain
{
    public class PoliceOfficer : Player
    {
        public PoliceOfficer(PoliceOfficerId policeOfficerId)
        {
            PoliceOfficerId = policeOfficerId;
        }

        public PoliceOfficerId PoliceOfficerId { get; }
    }
}