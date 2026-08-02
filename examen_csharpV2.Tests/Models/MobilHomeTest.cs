using examen_csharpV2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace examen_csharpV2.Tests.Models;

[TestClass]
public class MobilHomeTest
{
    /// <summary>
    /// Teste que le constructeur initialise correctement les attributs
    /// </summary>
    [TestMethod]
    public void Constructeur_InitialiseAttributsCorrectement()
    {
        // Arrange & Act
        MobilHome mobilHome = new MobilHome("6-PQR-678", "Hymer B678", 150, 12000, 6);

        // Assert
        Assert.AreEqual("6-PQR-678", mobilHome.Immatriculation);
        Assert.AreEqual("Hymer B678", mobilHome.Modele);
        Assert.AreEqual(150, mobilHome.PrixJournalier);
        Assert.AreEqual(12000, mobilHome.Kilometrage);
        Assert.AreEqual(6, mobilHome.NbCouchage);
        Assert.IsTrue(mobilHome.EstDisponible);
        Assert.AreEqual("B", mobilHome.PermisRequis);
    }

    /// <summary>
    /// Teste que le permis requis est B pour un mobil home
    /// </summary>
    [TestMethod]
    public void Constructeur_PermisRequisEstB()
    {
        // Arrange & Act
        MobilHome mobilHome = new MobilHome("6-PQR-678", "Hymer B678", 150, 12000, 6);

        // Assert
        Assert.AreEqual("B", mobilHome.PermisRequis);
    }

    /// <summary>
    /// Teste que le nombre de couchages est correctement initialisé
    /// </summary>
    [TestMethod]
    public void Constructeur_NbCouchageInitialiseCorrectement()
    {
        // Arrange & Act
        MobilHome mobilHome = new MobilHome("6-PQR-678", "Hymer B678", 150, 12000, 6);

        // Assert
        Assert.AreEqual(6, mobilHome.NbCouchage);
    }
}