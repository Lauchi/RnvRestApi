using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Domain
{
    public abstract class Player
    {
        public Player(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public IEnumerable<Station> VisitedStations { get; } = new Collection<Station>();
        public IEnumerable<VehicelType> UsedVehicles { get; } = new Collection<VehicelType>();

        public Tickets Tickets { get; }
    }
}