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
    public class AlbumPageViewModel : ViewModelBase
    {

        private ICustomNavigation _navigationService;
        private IProjectAppService _projectAppService;

        public AlbumPageViewModel(ICustomNavigation navigationService, IProjectAppService projectAppService)
        {
            _navigationService = navigationService;
            _projectAppService = projectAppService;
            LoadDataAllAlbums().GetAwaiter();
        }

        public async Task LoadDataAllAlbums()
        {
            try
            {
                Albums = await _projectAppService.GetAlbums();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //public async Task LoadSearchData()
        //{
        //    Task<List<Album>> T = _projectAppService.SearchAlbum(SearchBar);
        //    await T.ContinueWith(t =>
        //    {
        //        Albums = T.Result;
        //        if (Albums.Count == 0)
        //        {
        //            ErrorMessage = "No results were found.";
        //        }
        //        else
        //        {
        //            ErrorMessage = "";
        //        }
        //    });
        //}

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

        private List<AlbumNews> _albums;
        public List<AlbumNews> Albums
        {
            get
            {
                return _albums;
            }
            set
            {
                _albums = value;
                RaisePropertyChanged(() => Albums);
            }
        }

        private Album _selectedAlbum;
        public Album SelectedAlbum
        {
            get
            {
                return _selectedAlbum;
            }
            set
            {
                _selectedAlbum = value;
                RaisePropertyChanged(() => SelectedAlbum);
                if (SelectedAlbum != null)
                {
                    Album Album = _selectedAlbum;
                    _navigationService.NavigateTo(Locator.AudioPage, Album);
                }
            }
        }



        //public RelayCommand SearchCommand
        //{
        //    get
        //    {
        //        return new RelayCommand(() =>
        //        {
        //            LoadSearchData().GetAwaiter();
        //        });
        //    }
        //}
    }
}
