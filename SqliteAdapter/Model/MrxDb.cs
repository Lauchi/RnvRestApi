using System.ComponentModel.DataAnnotations;

namespace SqliteAdapter.Model
{
    public class MrxDb
    {
        [Key]
        public string MrxId { get; set; }
        public string Name { get; set; }

        public string GameSessionDbId { get; set; }
    }
}