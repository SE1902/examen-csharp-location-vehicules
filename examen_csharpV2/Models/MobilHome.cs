namespace examen_csharpV2.Models;

public class MobilHome : Vehicule
{
    
    public int NbCouchage { get; set; }
    
    public MobilHome(string immatriculation, string modele, double prixJournalier, double kilometrage, int nbCouchage)
        : base(immatriculation, modele, prixJournalier, kilometrage)
    {
        NbCouchage = nbCouchage;
        PermisRequis = "B";
    }
}