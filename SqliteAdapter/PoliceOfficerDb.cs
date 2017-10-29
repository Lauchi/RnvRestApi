using System.ComponentModel.DataAnnotations;

namespace SqliteAdapter
{
    public class PoliceOfficerDb
    {
        [Key]
        public string PoliceOfficerId { get; set; }
        public string Name { get; set; }

        public GameSessionDb GameSessionDb { get; set; }
        public TicketPoolDb TicketPoolDb { get; set; }

    }
}