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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public async Task LoadSearchData()
        //{
        //    AlbumNews albumNews = new AlbumNews();
        //    Lang AlbumName = new Lang();
        //    Images Images = new Images();

        //    Task<List<Album>> T = _projectAppService.SearchAlbum(SearchBar);
        //    await T.ContinueWith(t =>
        //    {
        //        foreach (Album album in T.Result)
        //        {
        //            album.image = Images.size315_111;

        //            albumNews.images = album.image;
        //            albumNews.title = album.name;

        //            var track = await SearchTrackById(id);
        //            tracks.Add(track);
        //        }
        //        return tracks;


        //        SearchAlbum = T.Result;
        //        T.
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

        //private string _errorMessage;
        //public string ErrorMessage
        //{
        //    get
        //    {
        //        return _errorMessage;
        //    }
        //    set
        //    {
        //        _errorMessage = value;
        //        RaisePropertyChanged(() => ErrorMessage);
        //    }
        //}

        //private string _searchBar;
        //public string SearchBar
        //{
        //    get
        //    {
        //        return _searchBar;
        //    }
        //    set
        //    {
        //        _searchBar = value;
        //        RaisePropertyChanged(() => SearchBar);
        //    }
        //}

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

        private AlbumNews _selectedAlbum;
        public AlbumNews SelectedAlbum
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
                    var uri = _selectedAlbum.link;
                    Uri urlAlbum = new Uri(uri);

                    _projectAppService.OpenBrowser(urlAlbum);
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
