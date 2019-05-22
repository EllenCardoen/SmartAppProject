using GalaSoft.MvvmLight;
using Project.Models;
using Project.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    public class MySongPlaylistPageViewModel : ViewModelBase
    {
        private ICustomNavigation _navigationService;
        private IProjectAppService _projectAppService;

        public MySongPlaylistPageViewModel(ICustomNavigation navigationservice, IProjectAppService projectAppService)
        {
            _navigationService = navigationservice;
            _projectAppService = projectAppService;
            LoadMySongsData().GetAwaiter();
        }

        public async Task LoadMySongsData()
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

        private Track _selectedTrack;
        public Track SelectedTrack
        {
            get
            {
                return _selectedTrack;
            }
            set
            {
                _selectedTrack = value;

                RaisePropertyChanged(() => SelectedTrack);
                if (SelectedTrack != null)
                {
                    Track Track = _selectedTrack;
                    _navigationService.NavigateTo(Locator.AudioPage, Track);
                }
            }
        }

    }
}
