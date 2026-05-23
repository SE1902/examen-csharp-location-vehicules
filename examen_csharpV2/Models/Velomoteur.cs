namespace examen_csharpV2.Models;

public class Velomoteur : Vehicule
{
    
    public int Cylindree { get; set; }
    
    public Velomoteur(string immatriculation, string modele, double prixJournalier, double kilometrage, int cylindree)
        : base(immatriculation, modele, prixJournalier, kilometrage)
    {
        this.Cylindree = cylindree;
        PermisRequis = "A/B";
    }

}