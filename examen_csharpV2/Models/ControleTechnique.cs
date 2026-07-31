namespace examen_csharpV2.Models;

/// <summary>
/// Classe représentant un contrôle technique d'un véhicule.
/// Le prochain contrôle est automatiquement planifié 2 ans après le contrôle actuel.
/// </summary>
public class ControleTechnique
{
    /// <summary>Véhicule concerné par le contrôle technique</summary>
    public Vehicule Vehicule { get; set; }
    
    /// <summary>Date à laquelle le contrôle technique a été effectué</summary>
    public DateTime DateControle { get; set; }
    
    /// <summary>Date du prochain contrôle technique (automatiquement 2 ans après)</summary>
    public DateTime DateProchainControle { get; set; }
    
    /// <summary>Indique si le contrôle technique est valide ou non</summary>
    public bool EstValide { get; set; }
    
    /// <summary>Observations notées lors du contrôle technique</summary>
    public string Observations { get; set; }

    /// <summary>
    /// Constructeur de la classe ControleTechnique.
    /// La date du contrôle est définie automatiquement à la date actuelle.
    /// Le prochain contrôle est planifié automatiquement 2 ans plus tard.
    /// </summary>
    /// <param name="vehicule">Véhicule à contrôler</param>
    /// <param name="observations">Observations du contrôle technique</param>
    /// <param name="estValide">Indique si le contrôle est valide ou non</param>
    public ControleTechnique(Vehicule vehicule, string observations, bool estValide)
    {
        Vehicule = vehicule;
        Observations = observations;
        EstValide = estValide;
        DateControle = DateTime.Now;
        DateProchainControle = DateTime.Now.AddYears(2);
    }

    /// <summary>
    /// Retourne une représentation textuelle du contrôle technique.
    /// Affiche le véhicule, les dates, la validité et les observations.
    /// </summary>
    /// <returns>Chaine de caractères avec les informations du contrôle technique</returns>
    public override string ToString()
    {
        string valide = EstValide ? "Valide" : "Non valide"; // if/else raccourci en 1 ligne 
        return $"{Vehicule.GetType().Name} {Vehicule.Immatriculation} | Contrôlé le : {DateControle.ToShortDateString()} | Prochain : {DateProchainControle.ToShortDateString()} | {valide} | {Observations}";
    }
}