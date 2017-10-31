using System;
using Domain.Validation;
using Domain.ValueTypes.Ids;

namespace Domain
{
    public class MrX : Player
    {
        public event Action MrxDeleted;
        private static MrX nullMrX = new MrX(new MrXId(new Guid().ToString()), "NaN");

        public MrX(MrXId mrXId, string name) : base(name)
        {
            MrXId = mrXId;
        }

        public MrXId MrXId { get;  }
        public static MrX NullValue { get; } = nullMrX;

        public MrX(string name) : base(name)
        {
            MrXId = new MrXId(Guid.NewGuid().ToString());
        }

        public DomainValidationResult Delete()
        {
            MrxDeleted?.Invoke();
            return DomainValidationResult.OkResult();
        }
    }
}