using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SqliteAdapter.Model
{
    public class PoliceOfficerDb
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<MovePoliceOfficerDb> MoveHistory { get; set; }
        public string CurrentStationId { get; set; }

        public string GameSessionDbId { get; set; }
        public GameSessionDb GameSessionDb { get; set; }
    }
}