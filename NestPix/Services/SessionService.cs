using NestPix.Models;

namespace NestPix.Services
{
    internal class SessionService
    {
        public SessionService() { }

        public static Session CurrentSession { get; private set; } = new Session();
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
                    Folder = folder,
                };
                db.Sessions.Add(session);
                db.SaveChanges();
                CurrentSession = session;
            }
        }

        public void UpdateSession(Session session)
        {
            using (var db = new AppDB())
            {
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
