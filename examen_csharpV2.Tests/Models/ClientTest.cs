using examen_csharpV2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace examen_csharpV2.Tests.Models;

[TestClass]
public class ClientTest
{
    /// <summary>
    /// Teste que le constructeur initialise correctement les attributs
    /// </summary>
    [TestMethod]
    public void Constructeur_InitialiseAttributsCorrectement()
    {
        // Arrange
        Client client = new Client("Dupont", "Jean", "B");

        // Assert
        Assert.AreEqual("Dupont", client.Nom);
        Assert.AreEqual("Jean", client.Prenom);
        Assert.IsTrue(client.Permis.Contains("B"));
    }

    /// <summary>
    /// Teste que la liste de permis est initialisée avec le permis donné
    /// </summary>
    [TestMethod]
    public void Constructeur_ListePermisInitialiseeAvecPermis()
    {
        // Arrange
        Client client = new Client("Dupont", "Jean", "B");

        // Assert
        Assert.AreEqual(1, client.Permis.Count);
        Assert.AreEqual("B", client.Permis[0]);
    }

    /// <summary>
    /// Teste qu'on peut ajouter un permis à la liste
    /// </summary>
    [TestMethod]
    public void Permis_PeutAjouterUnPermis()
    {
        // Arrange
        Client client = new Client("Dupont", "Jean", "B");

        // Act
        client.Permis.Add("A");

        // Assert
        Assert.AreEqual(2, client.Permis.Count);
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

        // Act
        string resultat = client.ToString();

        // Assert
        Assert.IsTrue(resultat.Contains("Dupont"));
        Assert.IsTrue(resultat.Contains("Jean"));
        Assert.IsTrue(resultat.Contains("B"));
    }
}