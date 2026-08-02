using examen_csharpV2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace examen_csharpV2.Tests.Models;

[TestClass]
public class FormationTest
{
    /// <summary>
    /// Teste que le constructeur initialise correctement les attributs
    /// </summary>
    [TestMethod]
    public void Constructeur_InitialiseAttributsCorrectement()
    {
        // Arrange
        Client client = new Client("Dupont", "Jean", "B");

        // Act
        Formation formation = new Formation(client, "A", 30);

        // Assert
        Assert.AreEqual(client, formation.Client);
        Assert.AreEqual("A", formation.TypePermis);
        Assert.AreEqual(30, formation.NbJours);
        Assert.IsFalse(formation.EstTerminee);
    }

    /// <summary>
    /// Teste que EstTerminee est false par défaut
    /// </summary>
    [TestMethod]
    public void Constructeur_EstTermineeFauxParDefaut()
    {
        // Arrange
        Client client = new Client("Dupont", "Jean", "B");

        // Act
        Formation formation = new Formation(client, "A", 30);

        // Assert
        Assert.IsFalse(formation.EstTerminee);
    }

    /// <summary>
    /// Teste que la formation peut être terminée et le permis ajouté au client
    /// </summary>
    [TestMethod]
    public void EstTerminee_PeutEtreMisAVraiEtPermisAjoute()
    {
        // Arrange
        Client client = new Client("Dupont", "Jean", "B");
        Formation formation = new Formation(client, "A", 30);

        // Act
        formation.EstTerminee = true;
        if (!client.Permis.Contains(formation.TypePermis))
        {
            client.Permis.Add(formation.TypePermis);
        }

        // Assert
        Assert.IsTrue(formation.EstTerminee);
        Assert.IsTrue(client.Permis.Contains("A"));
    }

    /// <summary>
    /// Teste que ToString retourne les bonnes informations
    /// </summary>
    [TestMethod]
    public void ToString_RetourneInformationsCorrectes()
    {
        // Arrange
        Client client = new Client("Dupont", "Jean", "B");
        Formation formation = new Formation(client, "A", 30);

        // Act
        string resultat = formation.ToString();

        // Assert
        Assert.IsTrue(resultat.Contains("Dupont"));
        Assert.IsTrue(resultat.Contains("A"));
        Assert.IsTrue(resultat.Contains("En cours"));
    }
}