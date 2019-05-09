using GalaSoft.MvvmLight.Ioc;
using Project.Repositories;
using Project.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.ViewModels
{
    public class Locator
    {
        public const string MainPage = "MainPage";
        public const string MasterPage = "MasterPage";
        public const string TabPage = "TabPage";
        public const string OverviewPage = "OverviewPage";
        public const string TrackPage = "TrackPage";
        public const string AlbumPage = "AlbumPage";
        public const string ArtistPage = "ArtistPage";
        public const string AudioPage = "AudioPage";
        public const string PlaylistPage = "PlaylistPage";
        public const string PlaylistTrackPage = "PlaylistTrackPage";
        public const string MySongPlaylistPage = "MySongPlaylistPage";


        public Locator()
        {
            SimpleIoc.Default.Register<ILocalDatabaseRepository, LocalDatabaseRepository>();
            SimpleIoc.Default.Register<ISearchRepository, SearchRepository>();
            SimpleIoc.Default.Register<IClientIdSettingsRepository, ClientIdSettingsRepository>();
            SimpleIoc.Default.Register<IBrowserRepository, BrowserRepository>();
            SimpleIoc.Default.Register<IShareRepository, ShareRepository>();
            

            SimpleIoc.Default.Register<IProjectAppService, ProjectAppService>();



            SimpleIoc.Default.Register<MainPageViewModel>();
            
            SimpleIoc.Default.Register<OverviewPageViewModel>();

            SimpleIoc.Default.Register<TrackPageViewModel>();

            SimpleIoc.Default.Register<AlbumPageViewModel>();

            SimpleIoc.Default.Register<ArtistPageViewModel>();

            SimpleIoc.Default.Register<AudioPageViewModel>();

            SimpleIoc.Default.Register<PlaylistPageViewModel>();

            SimpleIoc.Default.Register<PlaylistTrackPageViewModel>();

            SimpleIoc.Default.Register<MySongPlaylistPageViewModel>();

            SimpleIoc.Default.Register<TabPageViewModel>();
        }


        public MainPageViewModel MainPageViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<MainPageViewModel>();
            }
        }

        public OverviewPageViewModel OverviewPageViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<OverviewPageViewModel>();
            }
        }

        public TrackPageViewModel TrackPageViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<TrackPageViewModel>();
            }
        }

        public AlbumPageViewModel AlbumPageViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<AlbumPageViewModel>();
            }
        }

        public ArtistPageViewModel ArtistPageViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<ArtistPageViewModel>();
            }
        }

        public AudioPageViewModel AudioPageViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<AudioPageViewModel>();
            }
        }

        public PlaylistPageViewModel PlaylistPageViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<PlaylistPageViewModel>();
            }
        }

        public PlaylistTrackPageViewModel PlaylistTrackPageViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<PlaylistTrackPageViewModel>();
            }
        }

        public MySongPlaylistPageViewModel MySongPlaylistPageViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<MySongPlaylistPageViewModel>();
            }
        }

        public TabPageViewModel TabPageViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<TabPageViewModel>();
            }
        }
    }
}
