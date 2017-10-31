using System.ComponentModel.DataAnnotations;

namespace SqliteAdapter.Model
{
    public class TicketPoolDb
    {
        [Key]
        public string TicketPoolId { get; set; }

        public int TaxiTickets { get; set; }
        public int BusTickets { get; set; }
        public int MetroTickets { get; set; }
        public int DoubleTickets { get; set; }
        public int BlackTickets { get; set; }
    }
}