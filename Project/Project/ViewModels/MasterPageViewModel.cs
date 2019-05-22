using GalaSoft.MvvmLight.Command;
using Project.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.ViewModels
{
    public class MasterPageViewModel
    {
        private ICustomNavigation _navigationService;
        private IProjectAppService _projectAppService;

        public MasterPageViewModel(ICustomNavigation navigationService, IProjectAppService projectAppService)
        {
            _navigationService = navigationService;
            _projectAppService = projectAppService;
        }

        //relaycommands

        public RelayCommand goMySongs
        {
            get
            {
                return new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(Locator.MySongPlaylistPage);
                });
            }
        }

        public RelayCommand logOff
        {
            get
            {
                return new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(Locator.MainPage);
                });
            }
        }


    }
}
