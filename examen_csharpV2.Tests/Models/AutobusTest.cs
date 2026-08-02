using examen_csharpV2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace examen_csharpV2.Tests.Models;

[TestClass]
public class AutobusTest
{
    /// <summary>
    /// Teste que le constructeur initialise correctement les attributs
    /// </summary>
    [TestMethod]
    public void Constructeur_InitialiseAttributsCorrectement()
    {
        // Arrange & Act
        Autobus autobus = new Autobus("8-VWX-234", "Mercedes Sprinter", 180, 30000, 20);

        // Assert
        Assert.AreEqual("8-VWX-234", autobus.Immatriculation);
        Assert.AreEqual("Mercedes Sprinter", autobus.Modele);
        Assert.AreEqual(180, autobus.PrixJournalier);
        Assert.AreEqual(30000, autobus.Kilometrage);
        Assert.AreEqual(20, autobus.NbPlaces);
        Assert.IsTrue(autobus.EstDisponible);
        Assert.IsTrue(autobus.ChauffeurObligatoire);
    }

    /// <summary>
    /// Teste que le chauffeur est obligatoire pour un autobus
    /// </summary>
    [TestMethod]
    public void Constructeur_ChauffeurObligatoireEstVrai()
    {
        // Arrange & Act
        Autobus autobus = new Autobus("8-VWX-234", "Mercedes Sprinter", 180, 30000, 20);

        // Assert
        Assert.IsTrue(autobus.ChauffeurObligatoire);
    }

    /// <summary>
    /// Teste que le nombre de places est correctement initialisé
    /// </summary>
    [TestMethod]
    public void Constructeur_NbPlacesInitialiseCorrectement()
    {
        // Arrange & Act
        Autobus autobus = new Autobus("8-VWX-234", "Mercedes Sprinter", 180, 30000, 20);

        // Assert
        Assert.AreEqual(20, autobus.NbPlaces);
    }
}