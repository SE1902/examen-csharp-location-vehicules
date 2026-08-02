using examen_csharpV2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace examen_csharpV2.Tests.Models;

[TestClass]
public class ControleTechniqueTest
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
        ControleTechnique controle = new ControleTechnique(voiture, "RAS", true);

        // Assert
        Assert.AreEqual(voiture, controle.Vehicule);
        Assert.AreEqual("RAS", controle.Observations);
        Assert.IsTrue(controle.EstValide);
    }

    /// <summary>
    /// Teste que la date du prochain contrôle est 2 ans après
    /// </summary>
    [TestMethod]
    public void Constructeur_DateProchainControleEstDeuxAnsApres()
    {
        // Arrange
        Voiture voiture = new Voiture("1-ABC-123", "Renault Clio", 45, 15000);

        // Act
        ControleTechnique controle = new ControleTechnique(voiture, "RAS", true);

        // Assert
        Assert.AreEqual(DateTime.Now.Year + 2, controle.DateProchainControle.Year);
    }

    /// <summary>
    /// Teste qu'un contrôle non valide est correctement initialisé
    /// </summary>
    [TestMethod]
    public void Constructeur_ControleNonValideInitialiseCorrectement()
    {
        // Arrange
        Voiture voiture = new Voiture("1-ABC-123", "Renault Clio", 45, 15000);

        // Act
        ControleTechnique controle = new ControleTechnique(voiture, "Freins défectueux", false);

        // Assert
        Assert.IsFalse(controle.EstValide);
        Assert.AreEqual("Freins défectueux", controle.Observations);
    }

    /// <summary>
    /// Teste que ToString retourne les bonnes informations
    /// </summary>
    [TestMethod]
    public void ToString_RetourneInformationsCorrectes()
    {
        // Arrange
        Voiture voiture = new Voiture("1-ABC-123", "Renault Clio", 45, 15000);
        ControleTechnique controle = new ControleTechnique(voiture, "RAS", true);

        // Act
        string resultat = controle.ToString();

        // Assert
        Assert.IsTrue(resultat.Contains("Voiture"));
        Assert.IsTrue(resultat.Contains("RAS"));
        Assert.IsTrue(resultat.Contains("Valide"));
    }
}