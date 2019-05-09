using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Project.Models;
using Project.Repositories;
using Project.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    public class TrackPageViewModel : ViewModelBase
    {
        private ICustomNavigation _navigationService;
        private IProjectAppService _projectAppService;

        public TrackPageViewModel(ICustomNavigation navigationService, IProjectAppService projectAppService)
        {
            _navigationService = navigationService;
            _projectAppService = projectAppService;
            LoadDataAllTracks().GetAwaiter();
        }

        public async Task LoadDataAllTracks()
        {
            Tracks = await _projectAppService.GetAllTracks();
        }

        //NOG EEN METHODE MAKEN OM LIEDJES TE ZOEKEN IN DE LIJST VAN MYSONGS MET DE SEARCHBAR!!!!!!!

        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                RaisePropertyChanged(() => ErrorMessage);
            }
        }

        private string _searchBar;
        public string SearchBar
        {
            get
            {
                return _searchBar;
            }
            set
            {
                _searchBar = value;
                RaisePropertyChanged(() => SearchBar);
            }
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


        
        public RelayCommand SearchCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    //LoadSearchData().GetAwaiter();
                });
            }
        }

        public RelayCommand<DatabaseIdContent> addToPlaylist
        {
            get
            {
                return new RelayCommand<DatabaseIdContent>((DatabaseIdContent id) =>
                {
                    try
                    {
                        _projectAppService.AddTrackMySongs(id);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                });
            }
        }


    }
}
