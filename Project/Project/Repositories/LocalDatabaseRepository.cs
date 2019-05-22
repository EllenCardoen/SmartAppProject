using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Repositories
{
    public class LocalDatabaseRepository : ILocalDatabaseRepository
    {
        private string Path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "music.db");

        public void Setup()
        {
            try
            {
                using (var db = new DatabaseContext(Path))
                {
                    db.Database.EnsureCreated();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LocalDatabaseRepository()
        {
            Setup();
        }

        public void AddTrackMySongs(DatabaseIdContent id)
        {
            using (var db = new DatabaseContext(Path))
            {
                db.MySongs.Add(id);
                db.SaveChanges();
            }
        }

        public List<DatabaseIdContent> GetTracksMySongs()
        {
            using (var db = new DatabaseContext(Path))
            {
                return db.MySongs.ToList();
            }
        }

        public void deleteTrack(DatabaseIdContent id)
        {
            using (var db = new DatabaseContext(Path))
            {
                db.MySongs.Remove(id);
                db.SaveChanges();
            }
        }
    }
}
