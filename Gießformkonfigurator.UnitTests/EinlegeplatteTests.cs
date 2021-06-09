using Gießformkonfigurator.WindowsForms.Main.DBKlassen;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gießformkonfigurator.UnitTests
{
    [TestClass]
    public class EinlegeplatteTests
    {
        // Noch keine Testdaten vorhanden.
        [TestMethod]
        public void Kombiniere_konusEinlegeplatteKern_returnsTrue()
        {
            // Arrange
            var einlegeplatte = new Einlegeplatte() { Konus_Innen_Max = 265.31m, Konus_Innen_Min = 259.42m, Konus_Innen_Winkel = 15.00m, Mit_Konusfuehrung = true };
            var kern = new Kern() { Konus_Außen_Max = 265.00m, Konus_Außen_Min = 259.20m, Konus_Außen_Winkel = 15.00m, Mit_Konusfuehrung = true };

            // Act
            var result = einlegeplatte.Kombiniere(kern);

            // Assert
            Assert.IsTrue(result);
        }

        // Noch keine Testdaten vorhanden.
        [TestMethod]
        public void Kombiniere_lochEinlegeplatteKern_returnsTrue()
        {
            // Arrange
            var einlegeplatte = new Einlegeplatte() { Mit_Lochfuehrung = true, Innendurchmesser = 60, Hoehe = 8 };
            var kern = new Kern() { Mit_Fuehrungsstift = true, Durchmesser_Fuehrung = 60, Hoehe_Fuehrung = 8 };

            // Act
            var result = einlegeplatte.Kombiniere(kern);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
