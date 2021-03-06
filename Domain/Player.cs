﻿using System.Collections.Generic;
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
            MoveHistory = new Collection<Move>();
        }

        public ICollection<Move> MoveHistory { get; protected set; }

        public abstract DomainValidationResult Move(Station station, VehicelType vehicelType);

        public string Name { get;  }
    }
}