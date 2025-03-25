using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace NestPix.Models
{
    internal class AppDB : DbContext
    {
        public DbSet<Shortcuts> Shortcuts { get; set; }
        public DbSet<Session> Sessions { get; set; }

        public DbSet<SessionShortcut> SessionShortcuts { get; set; }

        public DbSet<Cache> Caches { get; set; }

        public DbSet<Hash> Hashes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shortcuts>().HasKey(Shortcut => Shortcut.Id);
            modelBuilder.Entity<Session>().HasKey(Session => Session.id);
            modelBuilder.Entity<SessionShortcut>().HasKey(SessionShortcut => new { SessionShortcut.SessionID, SessionShortcut.ShortcutID });
            modelBuilder.Entity<Cache>().HasKey(Cache => Cache.id);
            modelBuilder.Entity<Hash>().HasKey(Hash => Hash.id);

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
