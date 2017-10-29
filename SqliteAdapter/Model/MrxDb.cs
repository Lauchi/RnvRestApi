using System.ComponentModel.DataAnnotations;

namespace SqliteAdapter.Model
{
    public class MrxDb
    {
        [Key]
        public string MrxId { get; set; }
        public string Name { get; set; }

        public GameSessionDb GameSessionDb { get; set; }
        public TicketPoolDb TicketPoolDb { get; set; }
    }
}