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
            _projectAppService = projectAppService;
        }


        public RelayCommand playlistMySongs
        {
            get
            {
                return new RelayCommand(() =>
                {
                    _projectAppService.UpdateDatabase();
                    _navigationService.NavigateTo(Locator.MySongPlaylistPage);
                });
            }
        }
    }
}
