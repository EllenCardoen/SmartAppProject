using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Project.Models;
using Project.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    public class PlaylistPageViewModel : ViewModelBase
    {
        private ICustomNavigation _navigationService;
        private IProjectAppService _projectAppService;

        public PlaylistPageViewModel(ICustomNavigation navigationService, IProjectAppService projectAppService)
        {
            _navigationService = navigationService;
            //LoadDataPlaylist().GetAwaiter();
        }


        public RelayCommand playlistMySongs
        {
            get
            {
                return new RelayCommand(() =>
                {
                    //PlaylistInfo info = new PlaylistInfo() { name = "MySongs" };
                    _navigationService.NavigateTo(Locator.MySongPlaylistPage);
                });
            }
        }

        public RelayCommand playlistMyAlbums
        {
            get
            {
                return new RelayCommand(() =>
                {
                    string page = "MyAlbums";
                    _navigationService.NavigateTo(Locator.PlaylistTrackPage, page);
                });
            }
        }

        public RelayCommand playslistMyArtists
        {
            get
            {
                return new RelayCommand(() =>
                {
                    string page = "MyArtists";
                    _navigationService.NavigateTo(Locator.PlaylistTrackPage, page);
                });
            }
        }




    }
}
