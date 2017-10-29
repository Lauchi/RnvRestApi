using System;
using System.Collections.Generic;
using RnvRestApi.Domain.ValueTypes.Ids;
using RnvRestApi.DomainDtos;

namespace RnvRestApi.Domain
{
    public class MrX : Player
    {
        public MrXId MrXId { get; }
        public IEnumerable<StationDto> showedLocations { get; }
        public IEnumerable<VehicelType> usedVehicles { get; }

        public MrX(Tickets tickets) : base(tickets)
        {
        }
    }

    public abstract class Player
    {
        public string Name { get; set; }

        public Player(Tickets tickets)
        {
            Tickets = tickets;
        }
        public event Action<VehicelType, StationDto, Player> VehicleDrivenEvent;
        public event Action<VehicelType, Player> VehicleEmpty;

        public Tickets Tickets { get; }

        public void drive(VehicelType type, StationDto station)
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