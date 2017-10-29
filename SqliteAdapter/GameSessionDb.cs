using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SqliteAdapter
{
    public class GameSessionDb
    {
        [Key]
        public int GameSessionId { get; set; }

        public List<PoliceOfficerDb> PosPoliceOfficersts { get; set; }
        public MrxDb Mrx { get; set; }
    }
}