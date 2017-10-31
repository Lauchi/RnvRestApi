using System;
using Domain.ValueTypes.Ids;

namespace Domain
{
    public class MrX : Player
    {
        public MrX(MrXId mrXId, string name) : base(name)
        {
            MrXId = mrXId;
        }

        public MrXId MrXId { get;  }

        public MrX(string name) : base(name)
        {
            MrXId = new MrXId(Guid.NewGuid().ToString());
        }
    }
}