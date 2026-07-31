namespace examen_csharpV2.Models;

/// <summary>
/// Classe représentant un camion de l'agence de location.
/// Nécessite un permis C pour être loué.
/// Toujours accompagné d'un chauffeur obligatoire.
/// Hérite de la classe Vehicule.
/// </summary>
public class Camion : Vehicule
{
    /// <summary>Poids Total Autorisé en Charge (PTAC) du camion en tonnes</summary>
    public double Ptac { get; set; }

    /// <summary>
    /// Constructeur de la classe Camion.
    /// Appelle le constructeur de la classe parente Vehicule.
    /// Définit automatiquement le permis requis à C.
    /// </summary>
    /// <param name="immatriculation">Numéro d'immatriculation</param>
    /// <param name="modele">Modèle du camion</param>
    /// <param name="prixJournalier">Prix de location par jour</param>
    /// <param name="kilometrage">Kilométrage actuel</param>
    /// <param name="ptac">Poids Total Autorisé en Charge en tonnes</param>
    public Camion(string immatriculation, string modele, double prixJournalier, double kilometrage, double ptac)
        : base(immatriculation, modele, prixJournalier, kilometrage)
    {
        Ptac = ptac;
        PermisRequis = "C";
    }
}