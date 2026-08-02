using examen_csharpV2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace examen_csharpV2.Tests.Models;

[TestClass]
public class CamionTest
{
    /// <summary>
    /// Teste que le constructeur initialise correctement les attributs
    /// </summary>
    [TestMethod]
    public void Constructeur_InitialiseAttributsCorrectement()
    {
        // Arrange & Act
        Camion camion = new Camion("5-MNO-345", "Mercedes Actros", 120, 50000, 3.5);

        // Assert
        Assert.AreEqual("5-MNO-345", camion.Immatriculation);
        Assert.AreEqual("Mercedes Actros", camion.Modele);
        Assert.AreEqual(120, camion.PrixJournalier);
        Assert.AreEqual(50000, camion.Kilometrage);
        Assert.AreEqual(3.5, camion.Ptac);
        Assert.IsTrue(camion.EstDisponible);
        Assert.AreEqual("C", camion.PermisRequis);
    }

    /// <summary>
    /// Teste que le permis requis est C pour un camion
    /// </summary>
    [TestMethod]
    public void Constructeur_PermisRequisEstC()
    {
        // Arrange & Act
        Camion camion = new Camion("5-MNO-345", "Mercedes Actros", 120, 50000, 3.5);

        // Assert
        Assert.AreEqual("C", camion.PermisRequis);
    }

    /// <summary>
    /// Teste que le PTAC est correctement initialisé
    /// </summary>
    [TestMethod]
    public void Constructeur_PtacInitialiseCorrectement()
    {
        // Arrange & Act
        Camion camion = new Camion("5-MNO-345", "Mercedes Actros", 120, 50000, 3.5);

        // Assert
        Assert.AreEqual(3.5, camion.Ptac);
    }
}