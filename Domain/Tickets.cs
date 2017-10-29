using System.Collections.Generic;
using Domain.ValueTypes.Ids;

namespace Domain
{
    public class Tickets
    {
        public TicketPoolId TicketPoolId { get; }

        public Dictionary<VehicelType, int> Pool;

        public Tickets(int taxiTicket, int busTicket, int metroTicket, int doubleTicket, int blackTicket)
        {
            Pool.Add(VehicelType.Taxi, taxiTicket);
            Pool.Add(VehicelType.Bus, busTicket);
            Pool.Add(VehicelType.Metro, metroTicket);
            Pool.Add(VehicelType.DoubleTicket, doubleTicket);
            Pool.Add(VehicelType.BlackTicket, blackTicket);
        }

        public int GetAmmount(VehicelType vehicle)
        {
            Pool.TryGetValue(vehicle, out var value);
            return value;
        }

        public void Drive(VehicelType type)
        {
            Pool[type]--;
        }

        public void Add(VehicelType type)
        {
            Pool[type]++;
        }
    }
}