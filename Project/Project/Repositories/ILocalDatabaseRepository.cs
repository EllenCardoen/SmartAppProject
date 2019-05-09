using System.Collections.Generic;
using Project.Models;

namespace Project.Repositories
{
    public interface ILocalDatabaseRepository
    {
        void AddTrackMyAlbums(DatabaseIdContent id);
        void AddTrackMyArtists(DatabaseIdContent id);
        void AddTrackMySongs(DatabaseIdContent id);
        List<DatabaseIdContent> GetTracksMyAlbums();
        List<DatabaseIdContent> GetTracksMyArtists();
        List<DatabaseIdContent> GetTracksMySongs();
        void Setup();
    }
}