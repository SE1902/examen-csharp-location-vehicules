using examen_csharpV2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace examen_csharpV2.Tests.Models;

[TestClass]
public class VehiculeTest
{
    /// <summary>
    /// Teste que le constructeur initialise correctement les attributs
    /// </summary>
    [TestMethod]
    public void Constructeur_InitialiseAttributsCorrectement()
    {
        // Arrange - Préparer les données
        Voiture voiture = new Voiture("1-ABC-123", "Renault Clio", 45, 15000);

        // Assert - Vérifier que les attributs sont corrects
        Assert.AreEqual("1-ABC-123", voiture.Immatriculation);
        Assert.AreEqual("Renault Clio", voiture.Modele);
        Assert.AreEqual(45, voiture.PrixJournalier);
        Assert.AreEqual(15000, voiture.Kilometrage);
        Assert.IsTrue(voiture.EstDisponible);
        Assert.AreEqual("B", voiture.PermisRequis);
    }

    /// <summary>
    /// Teste que EstDisponible est true par défaut
    /// </summary>
    [TestMethod]
    public void Constructeur_EstDisponibleVraiParDefaut()
    {
        // Arrange
        Voiture voiture = new Voiture("1-ABC-123", "Renault Clio", 45, 15000);

        // Assert
        Assert.IsTrue(voiture.EstDisponible);
    }

    /// <summary>
    /// Teste que EstDisponible peut être mis à false
    /// </summary>
    [TestMethod]
    public void EstDisponible_PeutEtreMisAFaux()
    {
        // Arrange
        Voiture voiture = new Voiture("1-ABC-123", "Renault Clio", 45, 15000);

        // Act - Effectuer l'action
        voiture.EstDisponible = false;

        // Assert
        Assert.IsFalse(voiture.EstDisponible);
    }
}