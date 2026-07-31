namespace examen_csharpV2.Models;

/// <summary>
/// Classe représentant une moto de l'agence de location.
/// Nécessite un permis A pour être louée.
/// Hérite de la classe Vehicule.
/// </summary>
public class Moto : Vehicule
{
    /// <summary>Cylindrée de la moto en cm3</summary>
    public int Cylindree { get; set; }

    /// <summary>
    /// Constructeur de la classe Moto.
    /// Appelle le constructeur de la classe parente Vehicule.
    /// Définit automatiquement le permis requis à A.
    /// </summary>
    /// <param name="immatriculation">Numéro d'immatriculation</param>
    /// <param name="modele">Modèle de la moto</param>
    /// <param name="prixJournalier">Prix de location par jour</param>
    /// <param name="kilometrage">Kilométrage actuel</param>
    /// <param name="cylindree">Cylindrée de la moto en cm3</param>
    public Moto(string immatriculation, string modele, double prixJournalier, double kilometrage, int cylindree)
        : base(immatriculation, modele, prixJournalier, kilometrage)
    {
        Cylindree = cylindree;
        PermisRequis = "A";
    }
}