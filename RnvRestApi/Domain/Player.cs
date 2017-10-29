using System;

namespace RnvRestApi.Domain
{
    public abstract class Player
    {
        public string Name { get; set; }

        public Player(Tickets tickets)
        {
            Tickets = tickets;
        }
        public event Action<VehicelType, Station, Player> VehicleDrivenEvent;
        public event Action<VehicelType, Player> VehicleEmpty;

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

    public class Station
    {
    }
}