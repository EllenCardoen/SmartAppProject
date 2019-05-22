using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Project.Models;
using Project.Repositories;
using Project.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.LocalDatabase
{
    [TestClass]
    public class Tests_LocalDatabase
    {

        [TestMethod]
        public async Task Test_local_database()
        {
            //Arange
            var mockServicelocalDatabase = new Mock<ILocalDatabaseRepository>();
            var searchrepo = new Mock<ISearchRepository>().Object;
            var settingsRepo = new Mock<IClientIdSettingsRepository>().Object;
            var browserRepo = new Mock<IBrowserRepository>().Object;
            var shareRepo = new Mock<IShareRepository>().Object;

            List<DatabaseIdContent> dummyids = new List<DatabaseIdContent>()
            {
                new DatabaseIdContent(){id = "1"},
                new DatabaseIdContent(){id = "2"},
                new DatabaseIdContent(){id = "3"}
            };

            mockServicelocalDatabase.Setup(m => m.GetTracksMySongs()).Returns(await Task.FromResult(dummyids));

            var appService = new ProjectAppService(searchrepo, settingsRepo, mockServicelocalDatabase.Object, browserRepo, shareRepo);

            //Act

            var result = await appService.GetTracksMySongs();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<Track>));
        }
    }
}
