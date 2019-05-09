using Flurl.Http;
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
    public class MainPageViewModel : ViewModelBase
    {
        private ICustomNavigation _navigationService;
        private IClientIdSettingsRepository _settingRepository;
        private IProjectAppService _projectAppService;

        public MainPageViewModel(ICustomNavigation navigationService, IClientIdSettingsRepository settingRepository)
        {

            _navigationService = navigationService;
            _settingRepository = settingRepository;

        }

        private string _idEntry;
        public string IdEntry
        {
            get
            {
                return _idEntry;
            }
            set
            {
                _idEntry = value;
                RaisePropertyChanged(() => IdEntry);
            }
        }

        public RelayCommand startApp
        {
            get
            {
                return new RelayCommand(() =>
                {
                    try
                    {
                        string id = IdEntry;
                        _settingRepository.SaveClientId(id);

                        _navigationService.NavigateTo(Locator.MasterPage);
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                    
                });
            }
        }

    }
}
