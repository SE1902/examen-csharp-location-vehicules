namespace examen_csharpV2.Models;

public class Limousine : Vehicule
{
    public bool ChauffeurObligatoire { get; set; } = true;
    public int NbPassagers { get; set; }
    
    public Limousine(string immatriculation, string modele, double prixJournalier, double kilometrage, int nbPassagers)
        : base(immatriculation, modele, prixJournalier, kilometrage)
    {
        NbPassagers = nbPassagers;
        
    }
}