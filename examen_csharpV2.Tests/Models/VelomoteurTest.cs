using examen_csharpV2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace examen_csharpV2.Tests.Models;

[TestClass]
public class VelomoteurTest
{
    /// <summary>
    /// Teste que le constructeur initialise correctement les attributs
    /// </summary>
    [TestMethod]
    public void Constructeur_InitialiseAttributsCorrectement()
    {
        // Arrange & Act
        Velomoteur velomoteur = new Velomoteur("4-JKL-012", "Yamaha Neo", 25, 3000, 50);

        // Assert
        Assert.AreEqual("4-JKL-012", velomoteur.Immatriculation);
        Assert.AreEqual("Yamaha Neo", velomoteur.Modele);
        Assert.AreEqual(25, velomoteur.PrixJournalier);
        Assert.AreEqual(3000, velomoteur.Kilometrage);
        Assert.AreEqual(50, velomoteur.Cylindree);
        Assert.IsTrue(velomoteur.EstDisponible);
        Assert.AreEqual("A/B", velomoteur.PermisRequis);
    }

    /// <summary>
    /// Teste que le permis requis est A/B pour un vélomoteur
    /// </summary>
    [TestMethod]
    public void Constructeur_PermisRequisEstAOuB()
    {
        // Arrange & Act
        Velomoteur velomoteur = new Velomoteur("4-JKL-012", "Yamaha Neo", 25, 3000, 50);

        // Assert
        Assert.AreEqual("A/B", velomoteur.PermisRequis);
    }

    /// <summary>
    /// Teste que la cylindrée est correctement initialisée
    /// </summary>
    [TestMethod]
    public void Constructeur_CylindreeInitialiseeCorrectement()
    {
        // Arrange & Act
        Velomoteur velomoteur = new Velomoteur("4-JKL-012", "Yamaha Neo", 25, 3000, 50);

        // Assert
        Assert.AreEqual(50, velomoteur.Cylindree);
    }
}