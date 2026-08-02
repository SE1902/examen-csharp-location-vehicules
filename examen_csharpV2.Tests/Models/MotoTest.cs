using examen_csharpV2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace examen_csharpV2.Tests.Models;

[TestClass]
public class MotoTest
{
    /// <summary>
    /// Teste que le constructeur initialise correctement les attributs
    /// </summary>
    [TestMethod]
    public void Constructeur_InitialiseAttributsCorrectement()
    {
        // Arrange & Act
        Moto moto = new Moto("3-GHI-789", "Honda CBR", 60, 8000, 600);

        // Assert
        Assert.AreEqual("3-GHI-789", moto.Immatriculation);
        Assert.AreEqual("Honda CBR", moto.Modele);
        Assert.AreEqual(60, moto.PrixJournalier);
        Assert.AreEqual(8000, moto.Kilometrage);
        Assert.AreEqual(600, moto.Cylindree);
        Assert.IsTrue(moto.EstDisponible);
        Assert.AreEqual("A", moto.PermisRequis);
    }

    /// <summary>
    /// Teste que le permis requis est A pour une moto
    /// </summary>
    [TestMethod]
    public void Constructeur_PermisRequisEstA()
    {
        // Arrange & Act
        Moto moto = new Moto("3-GHI-789", "Honda CBR", 60, 8000, 600);

        // Assert
        Assert.AreEqual("A", moto.PermisRequis);
    }

    /// <summary>
    /// Teste que la cylindrée est correctement initialisée
    /// </summary>
    [TestMethod]
    public void Constructeur_CylindreeInitialiseeCorrectement()
    {
        // Arrange & Act
        Moto moto = new Moto("3-GHI-789", "Honda CBR", 60, 8000, 600);

        // Assert
        Assert.AreEqual(600, moto.Cylindree);
    }
}