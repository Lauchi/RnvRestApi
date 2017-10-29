using RnvRestApi.Domain.ValueTypes.Ids;

namespace RnvRestApi.Domain
{
    public class TicketPool
    {
        public TicketPoolId TicketPoolId { get; }
        public int TaxiTicket { get; }
        public int BusTicket { get; }
        public int MetroTicket { get; }
    }
}