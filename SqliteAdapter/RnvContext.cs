using Microsoft.EntityFrameworkCore;

namespace SqliteAdapter
{
    public class RnvContext : DbContext
    {
        public DbSet<GameSessionDb> GameSessions { get; set; }
        public DbSet<MrxDb> MrXs { get; set; }
        public DbSet<PoliceOfficerDb> PoliceOfficers { get; set; }
        public DbSet<TicketPoolDb> TicketPools { get; set; }
        public DbSet<MovementsDb> Movements { get; set; }
        public DbSet<VehicleTypeDb> VehicleTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=blogging.db");
        }
    }
}