using examen_csharpV2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace examen_csharpV2.Tests.Models;

[TestClass]
public class ReparationTest
{
    /// <summary>
    /// Teste que le constructeur initialise correctement les attributs
    /// </summary>
    [TestMethod]
    public void Constructeur_InitialiseAttributsCorrectement()
    {
        // Arrange
        Voiture voiture = new Voiture("1-ABC-123", "Renault Clio", 45, 15000);

        // Act
        Reparation reparation = new Reparation(voiture, "Pare-choc endommagé", 3);

        // Assert
        Assert.AreEqual(voiture, reparation.Vehicule);
        Assert.AreEqual("Pare-choc endommagé", reparation.Description);
        Assert.AreEqual(3, reparation.NbJours);
        Assert.IsFalse(reparation.EstTermine);
    }

    /// <summary>
    /// Teste que EstTermine est false par défaut
    /// </summary>
    [TestMethod]
    public void Constructeur_EstTermineFauxParDefaut()
    {
        // Arrange
        Voiture voiture = new Voiture("1-ABC-123", "Renault Clio", 45, 15000);

        // Act
        Reparation reparation = new Reparation(voiture, "Pare-choc endommagé", 3);

        // Assert
        Assert.IsFalse(reparation.EstTermine);
    }

    /// <summary>
    /// Teste que EstTermine peut être mis à true
    /// </summary>
    [TestMethod]
    public void EstTermine_PeutEtreMisAVrai()
    {
        // Arrange
        Voiture voiture = new Voiture("1-ABC-123", "Renault Clio", 45, 15000);
        Reparation reparation = new Reparation(voiture, "Pare-choc endommagé", 3);

        // Act
        reparation.EstTermine = true;
        voiture.EstDisponible = true;

        // Assert
        Assert.IsTrue(reparation.EstTermine);
        Assert.IsTrue(voiture.EstDisponible);
    }

    /// <summary>
    /// Teste que ToString retourne les bonnes informations
    /// </summary>
    [TestMethod]
    public void ToString_RetourneInformationsCorrectes()
    {
        // Arrange
        Voiture voiture = new Voiture("1-ABC-123", "Renault Clio", 45, 15000);
        Reparation reparation = new Reparation(voiture, "Pare-choc endommagé", 3);

        // Act
        string resultat = reparation.ToString();

        // Assert
        Assert.IsTrue(resultat.Contains("Voiture"));
        Assert.IsTrue(resultat.Contains("Pare-choc endommagé"));
        Assert.IsTrue(resultat.Contains("En cours"));
    }
}  