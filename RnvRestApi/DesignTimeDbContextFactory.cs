using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SqliteAdapter.Model;

namespace RnvRestApi
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RnvScotlandYardContext>
    {
        public RnvScotlandYardContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<RnvScotlandYardContext>();

            builder.UseSqlite("Data Source=rnvScotlandYard.db");

            return new RnvScotlandYardContext(builder.Options);
        }
    }

}