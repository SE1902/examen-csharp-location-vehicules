namespace examen_csharpV2.Models;

/// <summary>
/// Classe représentant un mobil home de l'agence de location.
/// Nécessite un permis B pour être loué.
/// Hérite de la classe Vehicule.
/// </summary>
public class MobilHome : Vehicule
{
    /// <summary>Nombre de places de couchage dans le mobil home</summary>
    public int NbCouchage { get; set; }

    /// <summary>
    /// Constructeur de la classe MobilHome.
    /// Appelle le constructeur de la classe parente Vehicule.
    /// Définit automatiquement le permis requis à B.
    /// </summary>
    /// <param name="immatriculation">Numéro d'immatriculation</param>
    /// <param name="modele">Modèle du mobil home</param>
    /// <param name="prixJournalier">Prix de location par jour</param>
    /// <param name="kilometrage">Kilométrage actuel</param>
    /// <param name="nbCouchage">Nombre de places de couchage</param>
    public MobilHome(string immatriculation, string modele, double prixJournalier, double kilometrage, int nbCouchage)
        : base(immatriculation, modele, prixJournalier, kilometrage)
    {
        NbCouchage = nbCouchage;
        PermisRequis = "B";
    }
}