using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    public class ProjectAppService : IProjectAppService
    {
        private ISearchRepository _searchRepository;
        private IClientIdSettingsRepository _settingsRepository;
        private ILocalDatabaseRepository _databaseRepository;
        private IBrowserRepository _browserRepository;
        private IShareRepository _shareRepository;

        public ProjectAppService(ISearchRepository searchRepository, IClientIdSettingsRepository settingsRepository, ILocalDatabaseRepository databaseRepository, IBrowserRepository browserRepository, IShareRepository shareRepository)
        {
            _searchRepository = searchRepository;
            _settingsRepository = settingsRepository;
            _databaseRepository = databaseRepository;
            _browserRepository = browserRepository;
            _shareRepository = shareRepository;
        }

        private string _clientId;
        public string ClientId
        {
            get => _clientId = _settingsRepository.GetClientId();
            set
            {
                _settingsRepository.SaveClientId(value);
            }
        }



        //van SearchRepository:

        public async Task<List<Track>> GetAllTracks()
        {
            return await _searchRepository.GetAllTracks(ClientId);
        }

        public async Task<List<Track>> SearchTrack(string searchRequest)
        {
            return await _searchRepository.SearchTrack(ClientId, searchRequest);
        }

        public async Task<Track> SearchTrackById(DatabaseIdContent id)
        {
            return await _searchRepository.SearchTrackById(ClientId, id);
        }

        public async Task<List<News>> GetNews()
        {
            return await _searchRepository.GetNews(ClientId);

        }

        public async Task<List<AlbumNews>> GetAlbums()
        {
            return await _searchRepository.GetAlbum(ClientId);
        }

        public async Task<List<Album>> SearchAlbum(string searchRequest)
        {
            return await _searchRepository.SearchAlbum(ClientId, searchRequest);
        }

        public async Task<List<ArtistNews>> GetArtists()
        {
            return await _searchRepository.GetArtist(ClientId);
        }


        //van ClientIdSettingsRepository:

        public void SaveClientId()
        {
            _settingsRepository.SaveClientId(ClientId);
        }

        public string GetClientId()
        {
            return _settingsRepository.GetClientId();
        }

        //van LocalDatabaseRepository:

        public void AddTrackMySongs(DatabaseIdContent id)
        {
            _databaseRepository.AddTrackMySongs(id);
        }

        public void AddTrackMyAlbums(DatabaseIdContent id)
        {
            _databaseRepository.AddTrackMyAlbums(id);
        }

        public void AddTrackMyArtists(DatabaseIdContent id)
        {
            _databaseRepository.AddTrackMyArtists(id);
        }

        public async Task<List<Track>> GetTracksMySongs()
        {
            List<Track> tracks = new List<Track>();
            foreach (DatabaseIdContent id in _databaseRepository.GetTracksMySongs())
            {
                var track = await SearchTrackById(id);
                tracks.Add(track);
            }
            return tracks;
        }

        public async Task<List<Track>> GetTracksMyAlbums()
        {
            List<Track> tracks = new List<Track>();
            foreach (DatabaseIdContent id in _databaseRepository.GetTracksMyAlbums())
            {
                //MOET NOG VERANDEREN NAAR SEARCHALBUMBYID
                var track = await SearchTrackById(id);
                tracks.Add(track);
            }
            return tracks;
        }

        public async Task<List<Track>> GetTracksMyArtists()
        {
            List<Track> tracks = new List<Track>();
            foreach (DatabaseIdContent id in _databaseRepository.GetTracksMyArtists())
            {
                //MOET NOG VERANDEREN NAAR SEARCHARTISTMYBID
                var track = await SearchTrackById(id);
                tracks.Add(track);
            }
            return tracks;
        }

        //van BrowserRepository:

        public void OpenBrowser(Uri uri)
        {
            _browserRepository.OpenBrowser(uri);
        }

        //van ShareRepository:

        public void ShareContent(string url)
        {
            _shareRepository.ShareContent(url);
        }

    }
}
