using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SqliteAdapter.Model
{
    public class GameSessionDb
    {
        [Key]
        public string GameSessionId { get; set; }
        public string Name { get; set; }
        public int MaxPoliceOfficers { get; set; }
        public DateTimeOffset StartTime { get; set; }

        public List<PoliceOfficerDb> PoliceOfficers { get; set; }
        public MrxDb Mrx { get; set; }
    }
}