using examen_csharpV2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace examen_csharpV2.Tests.Models;

[TestClass]
public class VoitureTest
{
    /// <summary>
    /// Teste que le constructeur initialise correctement les attributs
    /// </summary>
    [TestMethod]
    public void Constructeur_InitialiseAttributsCorrectement()
    {
        // Arrange & Act
        Voiture voiture = new Voiture("1-ABC-123", "Renault Clio", 45, 15000);

        // Assert
        Assert.AreEqual("1-ABC-123", voiture.Immatriculation);
        Assert.AreEqual("Renault Clio", voiture.Modele);
        Assert.AreEqual(45, voiture.PrixJournalier);
        Assert.AreEqual(15000, voiture.Kilometrage);
        Assert.IsTrue(voiture.EstDisponible);
        Assert.AreEqual("B", voiture.PermisRequis);
    }

    /// <summary>
    /// Teste que le permis requis est B pour une voiture
    /// </summary>
    [TestMethod]
    public void Constructeur_PermisRequisEstB()
    {
        // Arrange & Act
        Voiture voiture = new Voiture("1-ABC-123", "Renault Clio", 45, 15000);

        // Assert
        Assert.AreEqual("B", voiture.PermisRequis);
    }

    /// <summary>
    /// Teste que ToString retourne les bonnes informations
    /// </summary>
    [TestMethod]
    public void ToString_RetourneInformationsCorrectes()
    {
        // Arrange
        Voiture voiture = new Voiture("1-ABC-123", "Renault Clio", 45, 15000);

        // Act
        string resultat = voiture.ToString();

        // Assert
        Assert.IsTrue(resultat.Contains("1-ABC-123"));
        Assert.IsTrue(resultat.Contains("Renault Clio"));
        Assert.IsTrue(resultat.Contains("45"));
    }
}