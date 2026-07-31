namespace examen_csharpV2.Models;

/// <summary>
/// Classe représentant une limousine de l'agence de location.
/// Toujours accompagnée d'un chauffeur obligatoire.
/// Hérite de la classe Vehicule.
/// </summary>
public class Limousine : Vehicule
{
    /// <summary>Indique que le chauffeur est toujours obligatoire pour une limousine</summary>
    public bool ChauffeurObligatoire { get; set; } = true;
    
    /// <summary>Nombre maximum de passagers dans la limousine</summary>
    public int NbPassagers { get; set; }

    /// <summary>
    /// Constructeur de la classe Limousine.
    /// Appelle le constructeur de la classe parente Vehicule.
    /// Le chauffeur est toujours obligatoire pour une limousine.
    /// </summary>
    /// <param name="immatriculation">Numéro d'immatriculation</param>
    /// <param name="modele">Modèle de la limousine</param>
    /// <param name="prixJournalier">Prix de location par jour</param>
    /// <param name="kilometrage">Kilométrage actuel</param>
    /// <param name="nbPassagers">Nombre maximum de passagers</param>
    public Limousine(string immatriculation, string modele, double prixJournalier, double kilometrage, int nbPassagers)
        : base(immatriculation, modele, prixJournalier, kilometrage)
    {
        NbPassagers = nbPassagers;
    }
}