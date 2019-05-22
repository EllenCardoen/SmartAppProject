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

        public PlaylistPageViewModel(ICustomNavigation navigationService)
        {
            _navigationService = navigationService;
        }


        public RelayCommand playlistMySongs
        {
            get
            {
                return new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(Locator.MySongPlaylistPage);
                });
            }
        }
    }
}
