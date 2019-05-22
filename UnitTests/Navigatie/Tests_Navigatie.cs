using GalaSoft.MvvmLight.Ioc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Project;
using Project.Models;
using Project.Repositories;
using Project.Services;
using Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace UnitTests.Navigatie
{
    [TestClass]
    public class Tests_Navigatie
    {
        [ClassInitialize]
        public static void StartUp(TestContext testContext)
        {
            if (Application.Current != null)
                return;

            //altijd nodig voor Xamarin 
            Xamarin.Forms.Mocks.MockForms.Init();
            Application.Current = new App();
        }


        [ClassCleanup]
        public static void CleanUp()
        {
            Application.Current = null;
        }


        [TestMethod]
        public void NavigateMainPageToTabPageMasterPage_Test()
        {

            //arrange
            ICustomNavigation navigation =  SimpleIoc.Default.GetInstance<ICustomNavigation>();
            Mock<IClientIdSettingsRepository> mockedRepo = new Mock<IClientIdSettingsRepository>();
            //setup
            
            IClientIdSettingsRepository repo = mockedRepo.Object;

            MainPageViewModel mainPageViewModel = new MainPageViewModel(navigation, repo);

            //act
            mainPageViewModel.startApp.Execute(null);

            //assert
            Assert.AreEqual<string>(Locator.MasterPage, navigation.CurrentPageKey);
        }

        [TestMethod]
        public void NavigatePlaylistPageToMySongPlaylistPage_Test()
        {

            //arrange
            ICustomNavigation navigation = SimpleIoc.Default.GetInstance<ICustomNavigation>();

            PlaylistPageViewModel playlistPage = new PlaylistPageViewModel(navigation);

            //act
            playlistPage.playlistMySongs.Execute(null);

            //assert
            Assert.AreEqual<string>(Locator.MySongPlaylistPage, navigation.CurrentPageKey);
        }

        [TestMethod]
        public void NavigateTrackPageToAudioPage_Test()
        {

            //arrange
            ICustomNavigation navigation = SimpleIoc.Default.GetInstance<ICustomNavigation>();
            IProjectAppService appService = new Mock<IProjectAppService>().Object;

            TrackPageViewModel trackPage = new TrackPageViewModel(navigation, appService);

            Track track = new Track()
            {
                id = "test",
                name = "test",
                duration = 4,
                artist_id = "test",
                artist_name = "test",
                artist_idstr = "test",
                album_name = "test",
                album_id = "test",
                license_ccurl = "test",
                position = 1,
                releasedate = "test",
                album_image = "test",
                audio = "test",
                audiodownload = "test",
                prourl = "test",
                shorturl = "test",
                shareurl = "test",
                waveform = "test",
                image = "test",
            };

            //act
            trackPage.SelectedTrack = track;
            

            //assert
            Assert.AreEqual<string>(Locator.AudioPage, navigation.CurrentPageKey);
        }
    }
}
