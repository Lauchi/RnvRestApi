using System.Collections.Generic;
using System.Collections.ObjectModel;
using Domain.Validation;
using Domain.ValueTypes;

namespace Domain
{
    public abstract class Player
    {
        public Player(string name)
        {
            Name = name;
        }

        public Station CurrentStation { get; protected set; }

        public ICollection<Move> MoveHistory { get; } = new Collection<Move>();

        public abstract DomainValidationResult Move(Station station, VehicelType vehicelType);

        public string Name { get;  }
    }
}