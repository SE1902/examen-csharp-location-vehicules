namespace examen_csharpV2.Models;

/// <summary>
/// Classe représentant une location de véhicule.
/// Gère le contrat entre un client et un véhicule avec calcul automatique du prix.
/// </summary>
public class Location
{
    /// <summary>Client qui effectue la location</summary>
    public Client Client { get; set; }
    
    /// <summary>Véhicule loué</summary>
    public Vehicule Vehicule { get; set; }
    
    /// <summary>Chauffeur assigné à la location (nullable car optionnel selon le véhicule)</summary>
    public Chauffeur? Chauffeur { get; set; }
    
    /// <summary>Date de début de la location</summary>
    public DateTime Datedebut { get; set; }
    
    /// <summary>Nombre de jours de location</summary>
    public int NbJours { get; set; }
    
    /// <summary>Montant total calculé automatiquement (PrixJournalier x NbJours)</summary>
    public double MontantTotal { get; set; }
    
    /// <summary>Indique si la location est terminée</summary>
    public bool EstTerminee { get; set; }

    /// <summary>
    /// Constructeur de la classe Location.
    /// Calcule automatiquement le montant total à la création.
    /// La date de début est définie automatiquement à la date actuelle.
    /// </summary>
    /// <param name="client">Client qui effectue la location</param>
    /// <param name="vehicule">Véhicule à louer</param>
    /// <param name="nbJours">Nombre de jours de location</param>
    /// <param name="chauffeur">Chauffeur optionnel selon le type de véhicule</param>
    public Location(Client client, Vehicule vehicule, int nbJours, Chauffeur? chauffeur = null)
    {
        Client = client;
        Vehicule = vehicule;
        NbJours = nbJours;
        Chauffeur = chauffeur;
        Datedebut = DateTime.Now;
        MontantTotal = vehicule.PrixJournalier * nbJours;
        EstTerminee = false;
    }

    /// <summary>
    /// Retourne une représentation textuelle de la location.
    /// Affiche le client, le véhicule, la durée, le montant et le statut.
    /// </summary>
    /// <returns>Chaine de caractères avec les informations de la location</returns>
    public override string ToString()
    {
        string chauffeur = Chauffeur != null ? $"Chauffeur : {Chauffeur.Nom}" : "Sans chauffeur";
        string statut = EstTerminee ? "Terminée" : "En cours";
        return $"{Client.Nom} {Client.Prenom} | {Vehicule.GetType().Name} {Vehicule.Immatriculation} | {NbJours} jours | {MontantTotal}€ | {statut}";
    }
}