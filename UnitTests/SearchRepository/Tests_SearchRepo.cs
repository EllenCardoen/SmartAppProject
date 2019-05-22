using Flurl.Http.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.SearchRepo
{
    [TestClass]
    public class Tests_SearchRepo
    {
        [TestMethod]
        public async Task Test_GetALbum()
        {

            using (var httpTest = new HttpTest())
            {
                //Arange
                var SearchRepostiory = new SearchRepository();
                httpTest.RespondWith(new StringContent("{'results':[{id: 326, title: {en: 'Lilly Wolf'}, link: 'ok', position: 12, lang: ['en'], date_start: '2015-09-23 00:00:00', date_end: '2200-01-01 00:00:00', text: {'en':'First Album'}, type: 'album', joinid: 152029, subtitle: {'en':'Deleted Scenes'}, target: 'all', images: {'size996_350':'https://imgjam1.jamendo.com/feeds/22/322.996_350.jpg?du=2015-09-16+09%3A36%3A13'}}]}"), 200);

                //Act
                var result = await SearchRepostiory.GetAlbum("2938a4c0");

                //Assert
                //getResponse.SelectToken("results").ToObject<List<AlbumNews>>()
                httpTest.ShouldHaveCalled("https://api.jamendo.com/v3.0/feeds/?client_id=2938a4c0&format=jsonpretty&limit=10&type=album")
                    .WithVerb(HttpMethod.Get);

                Assert.IsNotNull(result);
                Assert.IsTrue(result.Count == 1);
            }
        }

        [TestMethod]
        public async Task Test_SearchTrack()
        {

            using (var httpTest = new HttpTest())
            {
                //Arange
                var SearchRepostiory = new SearchRepository();
                httpTest.RespondWith(new StringContent("{'results':[{id: '1873', name: 'L€ktro Pöppe', duration: 6, artist_id: '1907', artist_name: 'Maniax Memori', artist_idstr: 'hiphop2015', album_name: '2015', album_id: '155542', license_ccurl: 'http:/', position: 6, releasedate: '2006-05-09', album_image: 'https:/', audio: 'https:/', audiodownload: 'https:/', prourl: 'https:/', shorturl: 'http:/', shareurl: 'http:/', waveform: 'peaks\', image: 'https:/'}]}"), 200);

                //Act
                var result = await SearchRepostiory.SearchTrack("2938a4c0", "pop");

                //Assert
                httpTest.ShouldHaveCalled("https://api.jamendo.com/v3.0/tracks/?client_id=2938a4c0&format=jsonpretty&limit=20&search=pop")
                    .WithVerb(HttpMethod.Get);

                Assert.IsNotNull(result);
                Assert.IsTrue(result.Count == 1);
                Assert.IsInstanceOfType(result, typeof(List<Track>));
            }
        }

        [TestMethod]
        public async Task Test_GetArtist()
        {

            using (var httpTest = new HttpTest())
            {
                //Arange
                var SearchRepostiory = new SearchRepository();
                httpTest.RespondWith(new StringContent("{'results':[{id: '215', title: {en: 'Color Out'}, link: 'ok', position: '12', lang: ['en'], date_start: '2015-09-23 00:00:00', date_end: '2200-01-01 00:00:00', text: {'en':'First Album'}, type: 'artist', joinid: '152029', subtitle: [], target: 'all', images: {'size996_350':'https://imgjam1.jamendo.com/feeds/22/322.996_350.jpg?du=2015-09-16+09%3A36%3A13'}}]}"), 200);


                //Act
                var result = await SearchRepostiory.GetArtist("2938a4c0");

                //Assert
                httpTest.ShouldHaveCalled("https://api.jamendo.com/v3.0/feeds/?client_id=2938a4c0&format=jsonpretty&limit=30&type=artist")
                    .WithVerb(HttpMethod.Get);

                Assert.IsNotNull(result);
                Assert.IsTrue(result.Count == 1);
            }
        }
    }
}
