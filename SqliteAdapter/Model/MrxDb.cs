using System.ComponentModel.DataAnnotations;

namespace SqliteAdapter.Model
{
    public class MrxDb
    {
        [Key]
        public int MrxId { get; set; }
        public string Name { get; set; }

        public int GameSessionDbId { get; set; }
        public TicketPoolDb TicketPoolDb { get; set; }
    }
}