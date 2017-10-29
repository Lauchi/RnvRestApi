using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SqliteAdapter
{
    public class GameSessionDb
    {
        [Key]
        public int GameSessionId { get; set; }

        public ICollection<PoliceOfficerDb> PoliceOfficers { get; set; }
        public ICollection<MrxDb> Mrx { get; set; }
    }
}