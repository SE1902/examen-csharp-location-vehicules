namespace examen_csharpV2.Models;

/// <summary>
/// Classe représentant un autobus de l'agence de location.
/// Toujours accompagné d'un chauffeur obligatoire.
/// Hérite de la classe Vehicule.
/// </summary>
public class Autobus : Vehicule
{
    /// <summary>Indique que le chauffeur est toujours obligatoire pour un autobus</summary>
    public bool ChauffeurObligatoire { get; set; } = true;
    
    /// <summary>Nombre maximum de places dans l'autobus</summary>
    public int NbPlaces { get; set; }

    /// <summary>
    /// Constructeur de la classe Autobus.
    /// Appelle le constructeur de la classe parente Vehicule.
    /// Le chauffeur est toujours obligatoire pour un autobus.
    /// </summary>
    /// <param name="immatriculation">Numéro d'immatriculation</param>
    /// <param name="modele">Modèle de l'autobus</param>
    /// <param name="prixJournalier">Prix de location par jour</param>
    /// <param name="kilometrage">Kilométrage actuel</param>
    /// <param name="nbPlaces">Nombre maximum de places</param>
    public Autobus(string immatriculation, string modele, double prixJournalier, double kilometrage, int nbPlaces)
        : base(immatriculation, modele, prixJournalier, kilometrage)
    {
        NbPlaces = nbPlaces;
    }
}