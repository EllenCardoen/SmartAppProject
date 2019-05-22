using Flurl.Http.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Project.Models;
using Project.Repositories;
using Project.Services;
using Project.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class AllUnitTests
    {

        private readonly ISearchRepository _searchRepository;
        private readonly IClientIdSettingsRepository _settingsRepository;
        private readonly ILocalDatabaseRepository _databaseRepository;
        private readonly IBrowserRepository _browserRepository;
        private readonly IShareRepository _shareRepository;

        private readonly ICustomNavigation _navigationService;
        private readonly IProjectAppService _projectAppService;

        //HOE DUID JE RESULTS AAN OM TE DESERIALISEREN NAAR EEN OBJECT?????????? 

        [TestMethod]
        public async Task Test_Service_ApiCallsAsync()
        {
            
            using (var httpTest = new HttpTest())
            {
                //Arange
                var SearchRepostiory = new SearchRepository();
                httpTest.RespondWith(new StringContent("[{id: 326, title: 'Lilly Wolf', link: 'ok', position: 12, lang: 'en', date_start: '2015-09-23 00:00:00', date_end: '2200-01-01 00:00:00', text: 'First Album', type: 'album', joinid: 152029, subtitle: 'Deleted Scenes', target: 'all', images: 'https://imgjam1.jamendo.com/feeds/22/322.996_350.jpg?du=2015-09-16+09%3A36%3A13'}]"), 200);

                //Act
                var result = await SearchRepostiory.GetAlbum("2938a4c0");

                //Assert
                //getResponse.SelectToken("results").ToObject<List<AlbumNews>>()
                httpTest.ShouldHaveCalled("https://api.jamendo.com/v3.0/feeds/?client_id=2938a4c0&format=jsonpretty&limit=10&type=album")
                    .WithVerb(HttpMethod.Get)
                    .WithContentType("application/json");

                Assert.IsNotNull(result);
                Assert.IsTrue(result.Count == 1 );
            }
        }

        [TestMethod]
        public async Task Test_local_database()
        {
            //Arange
            var mockServicelocalDatabase = new Mock<ILocalDatabaseRepository>();
            List<DatabaseIdContent> dummyids = new List<DatabaseIdContent>()
            {
                new DatabaseIdContent(){id = "1"},
                new DatabaseIdContent(){id = "2"},
                new DatabaseIdContent(){id = "3"}
            };

            mockServicelocalDatabase.Setup(m => m.GetTracksMySongs()).Returns(await Task.FromResult(dummyids));

            var appService = new ProjectAppService(_searchRepository, _settingsRepository, mockServicelocalDatabase.Object, _browserRepository, _shareRepository);

            //Act

            var result = await appService.GetTracksMySongs();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<Track>));
        }

        [TestMethod]
        public void Test_ClientIdRepository()
        {
            {
                //HOE UNIT TEST JE XAMARIN.ESSENTIALS???????

                //Arange
                var mockessentials = new Mock<IPreferences>();

                string dummyClientId = new string("2938a4c0");

                mockessentials.Setup(m => m.Get(dummyClientId, "oke")).Returns(dummyClientId);

                var essentialsImplementation = new PreferencesImplementation();

                //Act
                //var result = essentialsImplementation. ;

                //Assert
                //Assert.IsNotNull(result);
                //Assert.AreEqual<string>("2938a4c0", result);

            }
        }

        [TestMethod]
        public void Test_Search_Method()
        {
            //Arange
            var TrackViewModel = new TrackPageViewModel(_navigationService, _projectAppService);

            //Act
            var result = TrackViewModel.LoadSearchData();

            //Assert
            Assert.IsNotNull(result);


        }

        //new Artist(){id = "1", name = "name1", website = "webiste1", joindate = "1", image = "1", shareurl = "1", shorturl = "1"},
        //new Artist(){id = "2", name = "name2", website = "website2", joindate = "2", image = "2", shareurl = "2", shorturl = "2"},
        //new Artist(){id = "3", name = "name3", website = "website3", joindate = "3", image = "3", shareurl = "3", shorturl = "3"}
    }
}
