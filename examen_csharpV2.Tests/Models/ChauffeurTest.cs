using examen_csharpV2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace examen_csharpV2.Tests.Models;

[TestClass]
public class ChauffeurTest
{
    /// <summary>
    /// Teste que le constructeur initialise correctement les attributs
    /// </summary>
    [TestMethod]
    public void Constructeur_InitialiseAttributsCorrectement()
    {
        // Arrange
        Chauffeur chauffeur = new Chauffeur("Leblanc", "Marc");

        // Assert
        Assert.AreEqual("Leblanc", chauffeur.Nom);
        Assert.AreEqual("Marc", chauffeur.Prenom);
        Assert.IsTrue(chauffeur.EstDisponible);
        Assert.AreEqual("", chauffeur.Raisonindisponibilite);
    }

    /// <summary>
    /// Teste que EstDisponible est true par défaut
    /// </summary>
    [TestMethod]
    public void Constructeur_EstDisponibleVraiParDefaut()
    {
        // Arrange
        Chauffeur chauffeur = new Chauffeur("Leblanc", "Marc");

        // Assert
        Assert.IsTrue(chauffeur.EstDisponible);
    }

    /// <summary>
    /// Teste que le chauffeur peut être mis indisponible
    /// </summary>
    [TestMethod]
    public void EstDisponible_PeutEtreMisAFaux()
    {
        // Arrange
        Chauffeur chauffeur = new Chauffeur("Leblanc", "Marc");

        // Act
        chauffeur.EstDisponible = false;
        chauffeur.Raisonindisponibilite = "Maladie";

        // Assert
        Assert.IsFalse(chauffeur.EstDisponible);
        Assert.AreEqual("Maladie", chauffeur.Raisonindisponibilite);
    }

    /// <summary>
    /// Teste que ToString retourne les bonnes informations quand disponible
    /// </summary>
    [TestMethod]
    public void ToString_RetourneDisponibleQuandDisponible()
    {
        // Arrange
        Chauffeur chauffeur = new Chauffeur("Leblanc", "Marc");

        // Act
        string resultat = chauffeur.ToString();

        // Assert
        Assert.IsTrue(resultat.Contains("Disponible"));
        Assert.IsTrue(resultat.Contains("Leblanc"));
    }

    /// <summary>
    /// Teste que ToString retourne la raison quand indisponible
    /// </summary>
    [TestMethod]
    public void ToString_RetourneRaisonQuandIndisponible()
    {
        // Arrange
        Chauffeur chauffeur = new Chauffeur("Leblanc", "Marc");

        // Act
        chauffeur.EstDisponible = false;
        chauffeur.Raisonindisponibilite = "Congé";
        string resultat = chauffeur.ToString();

        // Assert
        Assert.IsTrue(resultat.Contains("Indisponible"));
        Assert.IsTrue(resultat.Contains("Congé"));
    }
}