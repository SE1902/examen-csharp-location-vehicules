using examen_csharpV2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace examen_csharpV2.Tests.Models;

[TestClass]
public class LimousineTest
{
    /// <summary>
    /// Teste que le constructeur initialise correctement les attributs
    /// </summary>
    [TestMethod]
    public void Constructeur_InitialiseAttributsCorrectement()
    {
        // Arrange & Act
        Limousine limousine = new Limousine("7-STU-901", "Lincoln Town Car", 200, 5000, 8);

        // Assert
        Assert.AreEqual("7-STU-901", limousine.Immatriculation);
        Assert.AreEqual("Lincoln Town Car", limousine.Modele);
        Assert.AreEqual(200, limousine.PrixJournalier);
        Assert.AreEqual(5000, limousine.Kilometrage);
        Assert.AreEqual(8, limousine.NbPassagers);
        Assert.IsTrue(limousine.EstDisponible);
        Assert.IsTrue(limousine.ChauffeurObligatoire);
    }

    /// <summary>
    /// Teste que le chauffeur est obligatoire pour une limousine
    /// </summary>
    [TestMethod]
    public void Constructeur_ChauffeurObligatoireEstVrai()
    {
        // Arrange & Act
        Limousine limousine = new Limousine("7-STU-901", "Lincoln Town Car", 200, 5000, 8);

        // Assert
        Assert.IsTrue(limousine.ChauffeurObligatoire);
    }

    /// <summary>
    /// Teste que le nombre de passagers est correctement initialisé
    /// </summary>
    [TestMethod]
    public void Constructeur_NbPassagersInitialiseCorrectement()
    {
        // Arrange & Act
        Limousine limousine = new Limousine("7-STU-901", "Lincoln Town Car", 200, 5000, 8);

        // Assert
        Assert.AreEqual(8, limousine.NbPassagers);
    }
}