using GalaSoft.MvvmLight;
using Project.Models;
using Project.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    public class ArtistPageViewModel : ViewModelBase
    {
        private ICustomNavigation _navigationService;
        private IProjectAppService _projectAppService;

        public ArtistPageViewModel(ICustomNavigation navigationService, IProjectAppService projectAppService)
        {
            _navigationService = navigationService;
            _projectAppService = projectAppService;
            LoadArtistData().GetAwaiter();
        }

        public async Task LoadArtistData()
        {
            Artists = await _projectAppService.GetArtists();
        }

        private List<ArtistNews> _artists;
        public List<ArtistNews> Artists
        {
            get
            {
                return _artists;
            }
            set
            {
                _artists = value;
                RaisePropertyChanged(() => Artists);
            }
        }

        private ArtistNews _selectedArtist;
        public ArtistNews SelectedArtist
        {
            get
            {
                return _selectedArtist;
            }
            set
            {
                _selectedArtist = value;

                RaisePropertyChanged(() => SelectedArtist);
                if (SelectedArtist != null)
                {
                    var uri = _selectedArtist.link;
                    Uri urlArtist = new Uri(uri);

                    _projectAppService.OpenBrowser(urlArtist);
                }
            }
        }
    }
}
