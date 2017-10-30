using System.ComponentModel.DataAnnotations;

namespace SqliteAdapter.Model
{
    public class PoliceOfficerDb
    {
        [Key]
        public int PoliceOfficerId { get; set; }
        public string Name { get; set; }

        public GameSessionDb GameSessionDb { get; set; }
        public TicketPoolDb TicketPoolDb { get; set; }

    }
}