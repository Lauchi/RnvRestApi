using System.ComponentModel.DataAnnotations;

namespace SqliteAdapter.Model
{
    public class PoliceOfficerDb
    {
        [Key]
        public string PoliceOfficerId { get; set; }
        public string Name { get; set; }

        public string GameSessionDbId { get; set; }
        public GameSessionDb GameSessionDb { get; set; }

        public string TicketPoolDbId { get; set; }
        public TicketPoolDb TicketPoolDb { get; set; }

    }
}