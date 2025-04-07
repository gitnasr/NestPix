using NestPix.Models;

namespace NestPix.Services
{
    internal class SessionService
    {
        public SessionService() { }

        public static Session CurrentSession { get; private set; } = new Session();
        public void SetCurrentSession(Session session)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session), "Session cannot be null.");
            }
            CurrentSession = session;
        }
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
                CurrentSession = session;
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

        public void EndSession(Session session)
        {
            using (var db = new AppDB())
            {
                session.EndedAt = DateTime.Now;
                db.SaveChanges();
            }
        }
        public void GetSessionById(int id)
        {
            using (var db = new AppDB())
            {
                var session = db.Sessions.Find(id);
                if (session == null)
                {
                    throw new Exception($"Session with ID {id} not found.");
                }
                CurrentSession = session;
            }
        }

        public Session GetCurrentSession()
        {
            if (CurrentSession == null)
            {
                throw new InvalidOperationException("Current session is not set.");
            }
            return CurrentSession;
        }
    }
}
