namespace examen_csharpV2.Models;

/// <summary>
/// Classe représentant une formation de conduite pour l'obtention d'un permis.
/// Un client peut suivre une formation pour obtenir les permis A, B, C ou D.
/// </summary>
public class Formation
{
    /// <summary>Client qui suit la formation</summary>
    public Client Client { get; set; }
    
    /// <summary>Type de permis visé par la formation (A, B, C ou D)</summary>
    public string TypePermis { get; set; }
    
    /// <summary>Date de début de la formation</summary>
    public DateTime DateDebut { get; set; }
    
    /// <summary>Nombre de jours de formation</summary>
    public int NbJours { get; set; }
    
    /// <summary>Indique si la formation est terminée</summary>
    public bool EstTerminee { get; set; }

    /// <summary>
    /// Constructeur de la classe Formation.
    /// La date de début est définie automatiquement à la date actuelle.
    /// La formation est en cours par défaut à sa création.
    /// </summary>
    /// <param name="client">Client qui suit la formation</param>
    /// <param name="typePermis">Type de permis visé (A, B, C ou D)</param>
    /// <param name="nbJours">Nombre de jours de formation</param>
    public Formation(Client client, string typePermis, int nbJours)
    {
        Client = client;
        TypePermis = typePermis;
        NbJours = nbJours;
        DateDebut = DateTime.Now;
        EstTerminee = false;
    }

    /// <summary>
    /// Retourne une représentation textuelle de la formation.
    /// Affiche le client, le type de permis, la durée et le statut.
    /// </summary>
    /// <returns>Chaine de caractères avec les informations de la formation</returns>
    public override string ToString()
    {
        string statut = EstTerminee ? "Terminée" : "En cours";
        return $"{Client.Nom} {Client.Prenom} | Permis {TypePermis} | {NbJours} jours | {statut}";
    }
}