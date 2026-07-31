namespace examen_csharpV2.Models;

/// <summary>
/// Classe représentant un chauffeur salarié de l'agence de location.
/// Un chauffeur peut être assigné à certains véhicules comme la Limousine ou l'Autobus.
/// Il peut être indisponible en cas de congé ou maladie.
/// </summary>
public class Chauffeur
{
    /// <summary>Nom du chauffeur</summary>
    public string Nom { get; set; }
    
    /// <summary>Prénom du chauffeur</summary>
    public string Prenom { get; set; }
    
    /// <summary>Indique si le chauffeur est disponible pour une location</summary>
    public bool EstDisponible { get; set; }
    
    /// <summary>Raison de l'indisponibilité du chauffeur (Congé, Maladie...)</summary>
    public string Raisonindisponibilite { get; set; }

    /// <summary>
    /// Constructeur de la classe Chauffeur.
    /// Le chauffeur est disponible par défaut à sa création.
    /// </summary>
    /// <param name="nom">Nom du chauffeur</param>
    /// <param name="prenom">Prénom du chauffeur</param>
    public Chauffeur(string nom, string prenom)
    {
        Nom = nom;
        Prenom = prenom;
        EstDisponible = true;
        Raisonindisponibilite = "";
    }

    /// <summary>
    /// Retourne une représentation textuelle du chauffeur.
    /// Affiche son statut de disponibilité et la raison si indisponible.
    /// </summary>
    /// <returns>Chaine de caractères avec les informations du chauffeur</returns>
    public override string ToString()
    {
        if (EstDisponible)
            return $"{Nom} {Prenom} | Disponible";
        else
            return $"{Nom} {Prenom} | Indisponible ({Raisonindisponibilite})";
    }
}