using Domain.ValueTypes.Ids;

namespace Domain
{
    public class MrX : Player
    {
        public MrX(MrXId mrXId)
        {
            MrXId = mrXId;
        }

        public MrXId MrXId { get; }

        public static MrX NullValue()
        {
            return new MrX(new MrXId("NAN"));
        }
    }
}