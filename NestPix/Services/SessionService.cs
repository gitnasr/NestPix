using NestPix.Models;

namespace NestPix.Services
{
    internal class SessionService
    {
        public SessionService() { }

        public void CreateSession(string folder, int AlreadySeenCount, int FoldersCount)
        {
            using (var db = new AppDB())
            {
                Session session = new Session
                {
                    AlreadySeenCount = AlreadySeenCount,
                    FolderCount = FoldersCount,
                    CreatedAt = DateTime.Now,
                    LastInteraction = DateTime.Now,
                    Folder = folder
                };
                db.Sessions.Add(session);
                db.SaveChanges();
            }
        }
        public Session? GetLastSessionByFolder(string Folder)
        {
            using (var db = new AppDB())
            {
                if (string.IsNullOrEmpty(Folder))
                {
                    throw new ArgumentNullException(nameof(Folder), "Folder cannot be null or empty.");
                }
                if (!Directory.Exists(Folder))
                {
                    throw new DirectoryNotFoundException($"The specified folder does not exist: {Folder}");
                }

                var session = db.Sessions
                    .Where(s => s.Folder == Folder)
                    .OrderByDescending(s => s.CreatedAt)
                    .FirstOrDefault();
                if (session == null)
                {

                    return null;

                }
                return session;
            }

        }
        public void UpdateSession(Session session, int already_seen)
        {
            using (var db = new AppDB())
            {
                session.AlreadySeenCount = already_seen;
                session.LastInteraction = DateTime.Now;
                db.SaveChanges();
            }
        }
    }
}
