namespace examen_csharpV2.Models;

public class Moto : Vehicule
{
    
    public int Cylindree { get; set; }
    
    public Moto(string immatriculation, string modele, double prixJournalier, double kilometrage, int cylindree)
        : base(immatriculation, modele, prixJournalier, kilometrage)
    {
        Cylindree = cylindree;
        PermisRequis = "A";
    }
}