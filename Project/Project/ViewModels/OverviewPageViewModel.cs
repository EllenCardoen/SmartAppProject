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
    public class OverviewPageViewModel : ViewModelBase
    {
        private ICustomNavigation _navigationService;
        private IProjectAppService _projectAppService;

        Uri jamendo = new Uri("https://www.jamendo.com/explore");

        public OverviewPageViewModel(ICustomNavigation navigationservice, IProjectAppService projectAppService)
        {
            _navigationService = navigationservice;
            _projectAppService = projectAppService;
            LoadNewsData().GetAwaiter();
        }

        public async Task LoadNewsData()
        {
            News = await _projectAppService.GetNews();
        }

        //public async Task LoadNewsData()
        //{
        //    try
        //    {
        //        Task<List<News>> T = _projectAppService.GetNews();
        //        await T.ContinueWith(t =>
        //        {
        //            News = T.Result;
        //            fillList();
        //        });
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public async Task fillList()
        //{
        //    foreach (var news in News)
        //    {
        //        var title = news.title.en;
        //        TitleNews.Add(title);
        //    }
        //}

        private List<News> _news;
        public List<News> News
        {
            get
            {
                return _news;
            }
            set
            {
                _news = value;
                RaisePropertyChanged(() => News);
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

                //_autocompleteRepository.Autocomplete(IdEntry, _searchBar);
            }
        }


        public RelayCommand tracksSearch
        {
            get
            {
                return new RelayCommand(() =>
                {
                    try
                    {
                        _navigationService.NavigateTo(Locator.MasterPage);
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                    
                });
            }
        }

        public RelayCommand goToJamendo
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
