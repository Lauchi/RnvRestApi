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

        public event Action<VehicelType, Station, Player> VehicleDrivenEvent;
        public event Action<VehicelType, Player> VehicleEmpty;

        public IEnumerable<Station> VisitedStations { get; } = new Collection<Station>();
        public IEnumerable<VehicelType> usedVehicles { get; } = new Collection<VehicelType>();

        public Tickets Tickets { get; }

        public void drive(VehicelType type, Station station)
        {
            if (Tickets.GetAmmount(type) <= 0)
            {
                VehicleEmpty?.Invoke(type, this);
                // validation error
            }
            else
            {
                Tickets.Drive(type);
                VehicleDrivenEvent?.Invoke(type, station, this);
                //throw driven event
            }
        }
    }
}