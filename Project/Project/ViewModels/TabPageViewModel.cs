using GalaSoft.MvvmLight.Command;
using Project.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.ViewModels
{
    public class TabPageViewModel
    {
        private ICustomNavigation _navigationService;
        private IProjectAppService _projectAppService;

        Uri jamendo = new Uri("https://www.jamendo.com/explore");

        public TabPageViewModel(ICustomNavigation navigationService, IProjectAppService projectAppService)
        {
            _navigationService = navigationService;
            _projectAppService = projectAppService;
        }

        public RelayCommand exploreOnJamendo
        {
            get
            {
                return new RelayCommand(() =>
                {
                    _projectAppService.OpenBrowser(jamendo);
                });
            }
        }
    }
}
