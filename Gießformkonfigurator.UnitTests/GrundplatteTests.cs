using Gießformkonfigurator.WindowsForms.Main.DBKlassen;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gießformkonfigurator.UnitTests
{
    [TestClass]
    public class GrundplatteTests
    {
        // Produktivbeispiel eingefügt.
        /*
        [TestMethod]
        public void Kombiniere_grundplatteEinlegeplatte_returnsTrue()
        {
            // Arrange
            var grundplatte = new Grundplatte() { Konus_Innen_Max = 265.31m, Konus_Innen_Min = 259.42m, Konus_Innen_Winkel = 15.00m };
            var einlegeplatte = new Einlegeplatte() { Konus_Außen_Max = 265.00m, Konus_Außen_Min = 259.11m, Konus_Außen_Winkel = 15.00m };

            // Act
            var result = grundplatte.Kombiniere(einlegeplatte);

            // Assert
            Assert.IsTrue(result);
        }

        // Produktivbeispiel eingefügt.
        [TestMethod]
        public void Kombiniere_grundplatteFuehrungsring_returnsTrue()
        {
            // Arrange
            var grundplatte = new Grundplatte() 
            { Konus_Außen_Max = 347.89m, Konus_Außen_Min = 342.00m, Konus_Außen_Winkel = 15.00m, Konus_Hoehe = 11 };

            var ring = new Ring() 
            { Konus_Max = 345.43m, Konus_Min = 342.21m, Konus_Winkel = 15.00m, Konus_Hoehe = 6 };

            // Act
            var result = grundplatte.Kombiniere(ring);

            // Assert
            Assert.IsTrue(result);
        }

        // Noch keine Testdaten vorhanden.
        [TestMethod]
        public void Kombiniere_grundplatteKernKonus_returnsTrue()
        {
            // Arrange
            var grundplatte = new Grundplatte() { Mit_Konusfuehrung = true, Konus_Innen_Max = 200.00m, Konus_Innen_Min = 195.00m, Konus_Innen_Winkel = 15.00m };
            var kern = new Kern() { Mit_Konusfuehrung = true, Konus_Außen_Max = 199.00m, Konus_Außen_Min = 194.00m, Konus_Außen_Winkel = 15.00m };

            // Act
            var result = grundplatte.Kombiniere(kern);

            // Assert
            Assert.IsTrue(result);
        }

        // Produktivbeispiel eingefügt.
        [TestMethod]
        public void Kombiniere_grundplatteKernFuehrungsstift_returnsTrue()
        {
            // Arrange
            var grundplatte = new Grundplatte() { Mit_Lochfuehrung = true, Innendurchmesser =  15.00m, Hoehe = 20.00m };
            var kern = new Kern() { Mit_Fuehrungsstift = true, Durchmesser_Fuehrung = 15.00m, Hoehe_Fuehrung = 15.00m };

            // Act
            var result = grundplatte.Kombiniere(kern);

            // Assert
            Assert.IsTrue(result);
        }*/
    }
}
