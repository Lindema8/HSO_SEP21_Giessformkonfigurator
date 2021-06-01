using Gießformkonfigurator.WindowsForms.Main.DBKlassen;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gießformkonfigurator.UnitTests
{
    [TestClass]
    public class GrundplatteTests
    {
        [TestMethod]
        public void Kombiniere_grundplatteEinlegeplatte_returnsTrue()
        {
            // Arrange
            var grundplatte = new Grundplatte() { Konus_Innen_Max = 200.00m, Konus_Innen_Min = 195.00m, Konus_Innen_Winkel = 15.00m };
            var einlegeplatte = new Einlegeplatte() { Konus_Außen_Max = 199.00m, Konus_Außen_Min = 194.00m, Konus_Außen_Winkel = 15.00m };

            // Act
            var result = grundplatte.Kombiniere(einlegeplatte);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Kombiniere_grundplatteFuehrungsring_returnsTrue()
        {
            // Arrange
            var grundplatte = new Grundplatte() { Konus_Außen_Max = 200.00m, Konus_Außen_Min = 195.00m, Konus_Außen_Winkel = 15.00m, Konus_Hoehe = 20 };
            var ring = new Ring() { Konus_Max = 199.00m, Konus_Min = 194.00m, Konus_Winkel = 15.00m, Konus_Hoehe = 20 };

            // Act
            var result = grundplatte.Kombiniere(ring);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Kombiniere_grundplatteKern_returnsTrue()
        {
            // Arrange
            var grundplatte = new Grundplatte() { Konus_Innen_Max = 200.00m, Konus_Innen_Min = 195.00m, Konus_Innen_Winkel = 15.00m };
            var kern = new Kern() { Konus_Außen_Max = 199.00m, Konus_Außen_Min = 194.00m, Konus_Außen_Winkel = 15.00m };

            // Act
            var result = grundplatte.Kombiniere(kern);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
