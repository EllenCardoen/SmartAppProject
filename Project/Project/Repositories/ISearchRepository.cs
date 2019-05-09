using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Models;

namespace Project.Repositories
{
    public interface ISearchRepository
    {
        Task<List<AlbumNews>> GetAlbum(string clientId);
        Task<List<Track>> GetAllPlaylistTracks(string clientId, string userName, string PlaylistName);
        Task<List<Track>> GetAllTracks(string clientId);
        Task<List<ArtistNews>> GetArtist(string clientId);
        Task<List<News>> GetNews(string clientId);
        Task<List<Album>> SearchAlbum(string clientId, string searchRequest);
        Task<List<Track>> SearchTrack(string clientId, string searchRequest);
        Task<Track> SearchTrackById(string clientId, DatabaseIdContent id);
    }
}