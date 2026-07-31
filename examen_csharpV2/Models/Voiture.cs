namespace examen_csharpV2.Models;

/// <summary>
/// Classe représentant une voiture de l'agence de location.
/// Nécessite un permis B pour être louée.
/// Hérite de la classe Vehicule.
/// </summary>
public class Voiture : Vehicule
{
    /// <summary>
    /// Constructeur de la classe Voiture.
    /// Appelle le constructeur de la classe parente Vehicule.
    /// Définit automatiquement le permis requis à B.
    /// </summary>
    /// <param name="immatriculation">Numéro d'immatriculation</param>
    /// <param name="modele">Modèle du véhicule</param>
    /// <param name="prixJournalier">Prix de location par jour</param>
    /// <param name="kilometrage">Kilométrage actuel</param>
    public Voiture(string immatriculation, string modele, double prixJournalier, double kilometrage)
        : base(immatriculation, modele, prixJournalier, kilometrage)
    {
        PermisRequis = "B";
    }
}