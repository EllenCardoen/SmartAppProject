using GalaSoft.MvvmLight.Ioc;
using Project.Services;
using Project.ViewModels;
using Project.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Project
{
    public partial class App : Application
    {
        private static Locator _locator;
        public static Locator Locator
        {
            get
            {
                if(_locator == null)
                {
                    _locator = new Locator();
                }
                return _locator;
            }
        }

        public App()
        {
            InitializeComponent();

            //Setup Nav Service
            var nav = new NavigationService();
            nav.Configure(Locator.MainPage, typeof(MainPage));
            nav.Configure(Locator.MasterPage, typeof(MasterPage));
            nav.Configure(Locator.TabPage, typeof(TabPage));
            nav.Configure(Locator.TrackPage, typeof(TrackPage));
            nav.Configure(Locator.AlbumPage, typeof(AlbumPage));
            nav.Configure(Locator.AudioPage, typeof(AudioPage));
            nav.Configure(Locator.PlaylistPage, typeof(PlaylistPage));
            nav.Configure(Locator.MySongPlaylistPage, typeof(MySongPlaylistPage));
            nav.Configure(Locator.ArtistPage, typeof(ArtistPage));

            SimpleIoc.Default.Register<ICustomNavigation>(() => nav);


            var mainPage = new NavigationPage(new MainPage());
            nav.Initialize(mainPage);

            MainPage = mainPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
