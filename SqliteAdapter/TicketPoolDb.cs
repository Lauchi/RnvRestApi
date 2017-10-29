namespace SqliteAdapter
{
    public class TicketPoolDb
    {
        public string TicketPoolId { get; set; }

        public int TaxiTickets;
        public int BusTickets;
        public int MetroTickets;
        public int DoubleTickets;
        public int BlackTickets;
    }
}