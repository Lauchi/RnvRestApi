﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SqliteAdapter.Model
{
    public class PoliceOfficerDb
    {
        [Key]
        public string PoliceOfficerId { get; set; }
        public string Name { get; set; }

        public ICollection<MoveDb> MoveHistory { get; set; }
        public StationDb CurrentStation { get; set; }

        public string GameSessionDbId { get; set; }
        public GameSessionDb GameSessionDb { get; set; }
    }
}