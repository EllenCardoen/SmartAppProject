using GalaSoft.MvvmLight;
using Project.Models;
using Project.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    public class PlaylistTrackPageViewModel : ViewModelBase
    {
        private ICustomNavigation _navigationService;
        private IProjectAppService _projectAppService;

        public PlaylistTrackPageViewModel(ICustomNavigation navigationservice, IProjectAppService projectAppService)
        {
            _navigationService = navigationservice;
            _projectAppService = projectAppService;
            LoadPlaylistData().GetAwaiter();
        }

        public async Task LoadPlaylistData()
        {
            Tracks = await _projectAppService.GetTracksMySongs();
        }

        private List<Track> _tracks;
        public List<Track> Tracks
        {
            get
            {
                return _tracks;
            }
            set
            {
                _tracks = value;
                RaisePropertyChanged(() => Tracks);
            }
        } 

        private PlaylistInfo _playlistInfo;
        public PlaylistInfo PlayListInfo
        {
            get
            {
                return _playlistInfo;
            }
            set
            {
                _playlistInfo = value;
                RaisePropertyChanged(() => Tracks);
                NamePlaylist = _playlistInfo.name;
            }
        }

        private string _namePlaylist;
        public string NamePlaylist
        {
            get
            {
                return _namePlaylist;
            }
            set
            {
                _namePlaylist = value;
                RaisePropertyChanged(() => NamePlaylist);
            }
        }

    }
}
