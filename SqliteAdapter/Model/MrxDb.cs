using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SqliteAdapter.Model
{
    public class MrxDb
    {
        [Key]
        public string MrxId { get; set; }
        public string Name { get; set; }
        public ICollection<MoveMrXDb> MoveHistory { get; set; }
        public ICollection<OpenMoveMrxDb> OpenMoves { get; set; }
        public string LastKnownStation { get; set; }

        public string GameSessionDbId { get; set; }
    }
}