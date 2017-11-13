using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SqliteAdapter.Model
{
    public class MrxDb
    {
        [Key]
        public string MrxId { get; set; }
        public string Name { get; set; }
        public ICollection<MoveDb> MoveHistory { get; set; }
        public ICollection<MoveDb> OpenMoves { get; set; }
        public StationDb LastKnownStation { get; set; }

        public string GameSessionDbId { get; set; }
    }
}