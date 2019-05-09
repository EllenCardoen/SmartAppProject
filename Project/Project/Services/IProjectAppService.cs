using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Models;

namespace Project.Services
{
    public interface IProjectAppService
    {
        string ClientId { get; set; }

        void AddTrackMyAlbums(DatabaseIdContent id);
        void AddTrackMyArtists(DatabaseIdContent id);
        void AddTrackMySongs(DatabaseIdContent id);
        Task<List<AlbumNews>> GetAlbums();
        Task<List<Track>> GetAllTracks();
        Task<List<ArtistNews>> GetArtists();
        string GetClientId();
        Task<List<News>> GetNews();
        Task<List<Track>> GetTracksMyAlbums();
        Task<List<Track>> GetTracksMyArtists();
        Task<List<Track>> GetTracksMySongs();
        void OpenBrowser(Uri uri);
        void SaveClientId();
        Task<List<Album>> SearchAlbum(string searchRequest);
        Task<List<Track>> SearchTrack(string searchRequest);
        Task<Track> SearchTrackById(DatabaseIdContent id);
        void ShareContent(string url);
    }
}