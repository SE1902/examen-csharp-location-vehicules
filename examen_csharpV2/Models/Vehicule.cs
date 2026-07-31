namespace examen_csharpV2.Models;

/// <summary>
/// Classe de base représentant un véhicule de l'agence de location.
/// Toutes les classes de véhicules héritent de cette classe.
/// </summary>

public class Vehicule

{   //info de base des véhicules (hériatge)
    
    /// <summary>Numéro d'immatriculation du véhicule</summary>
    public string Immatriculation { get; set; }
    
    /// <summary>Type de permis requis pour conduire ce véhicule (nullable car certains véhicules ont un chauffeur obligatoire)</summary>
    public string? PermisRequis { get; set; } 
    
    /// <summary>Modèle du véhicule</summary>
    public string Modele { get; set; }
    
    /// <summary>Prix de location par jour en euros</summary>
    public double PrixJournalier { get; set; }
    
    /// <summary>Kilométrage actuel du véhicule</summary>
    public double Kilometrage { get; set; }
    
    /// <summary>Indique si le véhicule est disponible à la location</summary>
    public bool EstDisponible { get; set; }
    
    /// <summary>
    /// Constructeur de la classe Vehicule.
    /// Initialise les attributs communs à tous les véhicules.
    /// Le véhicule est disponible par défaut à sa création.
    /// </summary>
    /// <param name="immatriculation">Numéro d'immatriculation</param>
    /// <param name="modele">Modèle du véhicule</param>
    /// <param name="prixJournalier">Prix de location par jour</param>
    /// <param name="kilometrage">Kilométrage actuel</param>
    public Vehicule(string immatriculation, string modele, double prixJournalier, double kilometrage)
    {
        Immatriculation = immatriculation;
        Modele = modele;
        PrixJournalier = prixJournalier;
        Kilometrage = kilometrage;
        EstDisponible = true; // nouveau vehicule dispo par défaut 
    }
    
    // méthode pour afficher proprement un vehicule dans la console
    
    /// <summary>
    /// Retourne une représentation textuelle du véhicule.
    /// Utilisé pour afficher proprement un véhicule dans la console.
    /// </summary>
    /// <returns>Chaine de caractères avec les informations du véhicule</returns>

    public override string ToString()
    
    {
        return $"{GetType().Name} | {Immatriculation} | {Modele} | {PrixJournalier}€/jour | {Kilometrage}km";
    }
}