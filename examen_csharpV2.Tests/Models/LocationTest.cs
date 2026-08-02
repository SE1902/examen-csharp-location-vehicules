using examen_csharpV2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace examen_csharpV2.Tests.Models;

[TestClass]
public class LocationTest
{
    /// <summary>
    /// Teste que le constructeur initialise correctement les attributs
    /// </summary>
    [TestMethod]
    public void Constructeur_InitialiseAttributsCorrectement()
    {
        // Arrange
        Client client = new Client("Dupont", "Jean", "B");
        Voiture voiture = new Voiture("1-ABC-123", "Renault Clio", 45, 15000);

        // Act
        Location location = new Location(client, voiture, 3);

        // Assert
        Assert.AreEqual(client, location.Client);
        Assert.AreEqual(voiture, location.Vehicule);
        Assert.AreEqual(3, location.NbJours);
        Assert.IsNull(location.Chauffeur);
        Assert.IsFalse(location.EstTerminee);
    }

    /// <summary>
    /// Teste que le montant total est calculé automatiquement
    /// </summary>
    [TestMethod]
    public void Constructeur_CalculeMontantTotalAutomatiquement()
    {
        // Arrange
        Client client = new Client("Dupont", "Jean", "B");
        Voiture voiture = new Voiture("1-ABC-123", "Renault Clio", 45, 15000);

        // Act
        Location location = new Location(client, voiture, 3);

        // Assert - 45€/jour x 3 jours = 135€
        Assert.AreEqual(135, location.MontantTotal);
    }

    /// <summary>
    /// Teste que le constructeur initialise correctement avec un chauffeur
    /// </summary>
    [TestMethod]
    public void Constructeur_InitialiseAvecChauffeur()
    {
        // Arrange
        Client client = new Client("Martin", "Sophie", "A");
        Limousine limousine = new Limousine("7-STU-901", "Lincoln Town Car", 200, 5000, 8);
        Chauffeur chauffeur = new Chauffeur("Leblanc", "Marc");

        // Act
        Location location = new Location(client, limousine, 2, chauffeur);

        // Assert
        Assert.AreEqual(chauffeur, location.Chauffeur);
        Assert.AreEqual(400, location.MontantTotal);
    }

    /// <summary>
    /// Teste que EstTerminee est false par défaut
    /// </summary>
    [TestMethod]
    public void Constructeur_EstTermineeFauxParDefaut()
    {
        // Arrange
        Client client = new Client("Dupont", "Jean", "B");
        Voiture voiture = new Voiture("1-ABC-123", "Renault Clio", 45, 15000);

        // Act
        Location location = new Location(client, voiture, 3);

        // Assert
        Assert.IsFalse(location.EstTerminee);
    }

    /// <summary>
    /// Teste que EstTerminee peut être mis à true
    /// </summary>
    [TestMethod]
    public void EstTerminee_PeutEtreMisAVrai()
    {
        // Arrange
        Client client = new Client("Dupont", "Jean", "B");
        Voiture voiture = new Voiture("1-ABC-123", "Renault Clio", 45, 15000);
        Location location = new Location(client, voiture, 3);

        // Act
        location.EstTerminee = true;

        // Assert
        Assert.IsTrue(location.EstTerminee);
    }
}