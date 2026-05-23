namespace examen_csharpV2.Models;

public class Autobus : Vehicule
{
    public bool ChauffeurObligatoire { get; set; } = true;
    public int NbPlaces { get; set; }
    
    public Autobus(string immatriculation, string modele, double prixJournalier, double kilometrage, int nbPlaces)
        : base(immatriculation, modele, prixJournalier, kilometrage)
    {
        NbPlaces = nbPlaces;
        
    }
}