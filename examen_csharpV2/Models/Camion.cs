namespace examen_csharpV2.Models;

public class Camion : Vehicule
{
    
    public double Ptac { get; set; }

    public Camion(string immatriculation, string modele, double prixJournalier, double kilometrage, double ptac)
        : base(immatriculation, modele, prixJournalier, kilometrage)
    {
        Ptac = ptac;
        PermisRequis = "C";
    }
}