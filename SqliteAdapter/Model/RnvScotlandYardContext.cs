using Microsoft.EntityFrameworkCore;

namespace SqliteAdapter.Model
{
    public class RnvScotlandYardContext : DbContext
    {
        public RnvScotlandYardContext(DbContextOptions<RnvScotlandYardContext> options)
            : base(options)
        {
        }

        public DbSet<GameSessionDb> GameSessions { get; set; }
        public DbSet<MrxDb> MrXs { get; set; }
        public DbSet<PoliceOfficerDb> PoliceOfficers { get; set; }
        public DbSet<MoveDb> Moves { get; set; }
        public DbSet<StationDb> Stations { get; set; }
    }
}