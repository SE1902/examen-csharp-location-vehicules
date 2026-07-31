namespace examen_csharpV2.Service;

using examen_csharpV2.Models;

/// <summary>
/// Classe statique servant d'entrepôt central de données pour l'application.
/// Contient toutes les listes de données accessibles depuis n'importe quelle classe du programme.
/// Étant statique, aucun objet n'est nécessaire pour y accéder.
/// </summary>
public static class DataStore
{
    /// <summary>Liste de tous les véhicules de l'agence</summary>
    public static List<Vehicule> Vehicules { get; set; } = new List<Vehicule>();
    
    /// <summary>Liste de tous les clients de l'agence</summary>
    public static List<Client> Clients { get; set; } = new List<Client>();
    
    /// <summary>Liste de tous les chauffeurs de l'agence</summary>
    public static List<Chauffeur> Chauffeurs { get; set; } = new List<Chauffeur>();
    
    /// <summary>Liste de toutes les locations effectuées</summary>
    public static List<Location> Location { get; set; } = new List<Location>();
    
    /// <summary>Liste de toutes les réparations en cours ou terminées</summary>
    public static List<Reparation> Reparation { get; set; } = new List<Reparation>();
    
    /// <summary>Liste de tous les contrôles techniques effectués</summary>
    public static List<ControleTechnique> ControleTechnique { get; set; } = new List<ControleTechnique>();
    
    /// <summary>Liste de toutes les formations de conduite</summary>
    public static List<Formation> Formation { get; set; } = new List<Formation>();
}