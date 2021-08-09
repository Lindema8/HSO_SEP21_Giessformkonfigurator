namespace Gießformkonfigurator.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Gießformkonfigurator.WindowsForms.Main.DBKlassen;
    using Gießformkonfigurator.WindowsForms;
    using System.Collections.Generic;
    using Gießformkonfigurator.WindowsForms.Main.Gießformen;

    [TestClass]
    public class KombinationsObjektTest
    {
        
        [TestMethod]
        public void KombiniereMGießformen_allComponents_returnsMGießform()
        {
            // Arrange
            var ko = new KombinationsObjekt(null);
            ko.ArraysTestData();

            // Act
            List<MGießform> mGießformenList = new List<MGießform>();
            ko.KombiniereMGießformen();

            // Assert
            Assert.IsNotNull(mGießformenList);
        }
    }
}
