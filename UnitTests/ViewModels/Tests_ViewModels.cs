using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Project.Services;
using Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.ViewModels
{
    [TestClass]
    public class Tests_ViewModels
    {
        [TestMethod]
        public void Test_Search_Method()
        {
            //Arange
            var navigationService = new Mock<ICustomNavigation>().Object;
            var projectAppService = new Mock<IProjectAppService>().Object;
            var TrackViewModel = new TrackPageViewModel(navigationService, projectAppService);

            //Act
            var result = TrackViewModel.LoadSearchData();

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
