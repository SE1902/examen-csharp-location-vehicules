namespace examen_csharpV2.Models;

/// <summary>
/// Classe représentant un vélomoteur de l'agence de location.
/// Nécessite un permis A ou B pour être loué.
/// Hérite de la classe Vehicule.
/// </summary>
public class Velomoteur : Vehicule
{
    /// <summary>Cylindrée du vélomoteur en cm3</summary>
    public int Cylindree { get; set; }

    /// <summary>
    /// Constructeur de la classe Velomoteur.
    /// Appelle le constructeur de la classe parente Vehicule.
    /// Définit automatiquement le permis requis à A ou B.
    /// </summary>
    /// <param name="immatriculation">Numéro d'immatriculation</param>
    /// <param name="modele">Modèle du vélomoteur</param>
    /// <param name="prixJournalier">Prix de location par jour</param>
    /// <param name="kilometrage">Kilométrage actuel</param>
    /// <param name="cylindree">Cylindrée du vélomoteur en cm3</param>
    public Velomoteur(string immatriculation, string modele, double prixJournalier, double kilometrage, int cylindree)
        : base(immatriculation, modele, prixJournalier, kilometrage)
    {
        this.Cylindree = cylindree;
        PermisRequis = "A/B";
    }
} 