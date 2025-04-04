using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace NestPix.Models
{
    internal class AppDB : DbContext
    {
        public DbSet<Shortcuts> Shortcuts { get; set; }
        public DbSet<Session> Sessions { get; set; }


        public DbSet<Cache> Caches { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shortcuts>().HasKey(Shortcut => Shortcut.Id);
            modelBuilder.Entity<Session>().HasKey(Session => Session.id);
            modelBuilder.Entity<Cache>().HasKey(Cache => Cache.Id);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databasePath = $"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}app.db";
            optionsBuilder.LogTo(message => Debug.WriteLine(message));

            optionsBuilder.UseSqlite($"Data Source={databasePath}");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
