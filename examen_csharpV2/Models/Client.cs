namespace examen_csharpV2.Models;

/// <summary>
/// Classe représentant un client de l'agence de location.
/// Un client possède une liste de permis qui détermine quels véhicules il peut louer.
/// </summary>
public class Client
{
    /// <summary>Nom du client</summary>
    public string Nom { get; set; }
    
    /// <summary>Prénom du client</summary>
    public string Prenom { get; set; }
    
    /// <summary>Liste des permis de conduire du client (A, B, C, D)</summary>
    public List<string> Permis { get; set; }

    /// <summary>
    /// Constructeur de la classe Client.
    /// Initialise le client avec son nom, prénom et son premier permis.
    /// </summary>
    /// <param name="nom">Nom du client</param>
    /// <param name="prenom">Prénom du client</param>
    /// <param name="numPermis">Type de permis initial du client</param>
    public Client(string nom, string prenom, string numPermis)
    {
        Nom = nom;
        Prenom = prenom;
        Permis = new List<string> { numPermis };
    }

    /// <summary>
    /// Retourne une représentation textuelle du client.
    /// Affiche le nom, prénom et tous les permis du client.
    /// </summary>
    /// <returns>Chaine de caractères avec les informations du client</returns>
    public override string ToString()
    {
        return $"{Nom} {Prenom} | Permis : {string.Join(",", Permis)}";
    }
}