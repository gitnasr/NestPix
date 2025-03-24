﻿using NestPix.Models;

namespace NestPix.Services.DB_Services
{
    internal class ShortcutService
    {
        public ShortcutService() { }
        public ShortcutService(string name) { }

        public void AddShortcut(string name, Keys key, Actions action)
        {
            // Add a new shortcut to the database
            using (var db = new AppDB())
            {

                Shortcuts shortcut = new Shortcuts
                {
                    Key = key,
                    Action = action
                };
                db.Shortcuts.Add(shortcut);
                db.SaveChanges();

            }
        }
        public void RemoveShortcut(string name)
        {
            // Remove a shortcut from the database
        }

        public void UpdateShortcut(string name, Keys key, Actions action)
        {
            // Update a shortcut in the database
            using (var db = new AppDB())
            {

                Shortcuts? shortcut = db.Shortcuts.FirstOrDefault(Shortcut => Shortcut.Action == action);
                if (shortcut != null)
                {
                    shortcut.Key = key;
                    db.SaveChanges();
                }
                else
                {
                    AddShortcut(name, key, action);
                }

            }
        }

        public void GetShortcut(string name)
        {
            // Get a shortcut from the database
        }

        public Dictionary<Actions, Keys> GetShortcuts()
        {
            Dictionary<Actions, Keys> shortcuts = new Dictionary<Actions, Keys>();
            using (var db = new AppDB())
            {
                // Get all shortcuts from the database

                db.Shortcuts.Select(Shortcuts => new { Shortcuts.Action, Shortcuts.Key }).ToList().ForEach(Shortcut =>
                {
                    shortcuts.Add(Shortcut.Action, Shortcut.Key);
                });

            }
            return shortcuts;
        }
    }
}
