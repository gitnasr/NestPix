using Microsoft.EntityFrameworkCore;

namespace NestPix.Models
{
    internal class AppDB : DbContext
    {
        public DbSet<Shortcuts> Shortcuts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databasePath = $"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}app.db";

            optionsBuilder.UseSqlite($"Data Source={databasePath}");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
