namespace examen_csharpV2.Models;

public class Voiture : Vehicule
{
    
    public Voiture(string immatriculation, string modele, double prixJournalier, double kilometrage)
        : base(immatriculation, modele, prixJournalier, kilometrage)
    {
        PermisRequis = "B";
    }
}