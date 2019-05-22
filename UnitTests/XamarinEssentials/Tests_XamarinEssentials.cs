using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.XamarinEssentials
{
    [TestClass]
    public class Tests_XamarinEssentials
    {
        [TestMethod]
        public void Test_ClientIdRepository_Exception()
        {
            {
                //xamarin essenstials zijn niet te testen. dit zijn platform specifieke materie waar we geen access toe hebben.
                // in een unit test zitten we niet met een gsm te teste (of een emulator) waardoor we geen toegang hebben tot de essentials.
                //echter kunnen we hiermee wel aan tonen dat we ook excepties kunnen testen...

                //Arange
                var essentialsImplementation = new ClientIdSettingsRepository();

                // Act
                var result = Assert.ThrowsException<ArgumentException>(() => essentialsImplementation.GetClientId()); ;

                //Assert
                Assert.AreEqual("Device niet herkend", result.Message);
            }
        }
    }
}
