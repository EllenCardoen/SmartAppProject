using System.Collections.Generic;
using Project.Models;

namespace Project.Repositories
{
    public interface ILocalDatabaseRepository
    {
        void AddTrackMySongs(DatabaseIdContent id);
        void deleteTrack(DatabaseIdContent id);
        List<DatabaseIdContent> GetTracksMySongs();
        void Setup();
        void updateDatabase();
    }
}