namespace examen_csharpV2.Models;

/// <summary>
/// Classe représentant une réparation d'un véhicule de l'agence.
/// Quand un véhicule est endommagé, il est mis en réparation et devient indisponible.
/// </summary>
public class Reparation
{
    /// <summary>Véhicule en cours de réparation</summary>
    public Vehicule Vehicule { get; set; }
    
    /// <summary>Description de la réparation effectuée</summary>
    public string Description { get; set; }
    
    /// <summary>Date de début de la réparation</summary>
    public DateTime DateDbut { get; set; }
    
    /// <summary>Nombre de jours estimé pour la réparation</summary>
    public int NbJours { get; set; }
    
    /// <summary>Indique si la réparation est terminée</summary>
    public bool EstTermine { get; set; }

    /// <summary>
    /// Constructeur de la classe Reparation.
    /// La date de début est définie automatiquement à la date actuelle.
    /// La réparation est en cours par défaut à sa création.
    /// </summary>
    /// <param name="vehicule">Véhicule à réparer</param>
    /// <param name="description">Description de la réparation</param>
    /// <param name="nbJours">Nombre de jours estimé pour la réparation</param>
    public Reparation(Vehicule vehicule, string description, int nbJours)
    {
        Vehicule = vehicule;
        Description = description;
        NbJours = nbJours;
        DateDbut = DateTime.Now;
        EstTermine = false;
    }

    /// <summary>
    /// Retourne une représentation textuelle de la réparation.
    /// Affiche le véhicule, la description, la durée et le statut.
    /// </summary>
    /// <returns>Chaine de caractères avec les informations de la réparation</returns>
    public override string ToString()
    {
        string statut = EstTermine ? "Terminé" : "En cours";
        return $"{Vehicule.GetType().Name} {Vehicule.Immatriculation} | {Description} | {NbJours} jours | {statut}";
    }
}