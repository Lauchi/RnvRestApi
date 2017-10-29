using System.Collections.Generic;

namespace SqliteAdapter
{
    public class GameSessionDb
    {
        public string GameSessionId { get; set; }
        public string Url { get; set; }

        public List<PoliceOfficerDb> PosPoliceOfficersts { get; set; }
        public MrxDb Mrx { get; set; }
    }
}