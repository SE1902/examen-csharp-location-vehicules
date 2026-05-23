namespace examen_csharpV2.Models;

public class Vehicule

{   //info de base des véhicules (hériatge)
    public string Immatriculation { get; set; }
    public string? PermisRequis { get; set; } 
    public string Modele { get; set; }
    public double PrixJournalier { get; set; }
    public double Kilometrage { get; set; }
    public bool EstDisponible { get; set; }

    public Vehicule(string immatriculation, string modele, double prixJournalier, double kilometrage)
    {
        Immatriculation = immatriculation;
        Modele = modele;
        PrixJournalier = prixJournalier;
        Kilometrage = kilometrage;
        EstDisponible = true; // nouveau vehicule dispo par défaut 
    }
    
    // méthode pour afficher proprement un vehicule dans la console 

    public override string ToString()
    
    {
        return $"{GetType().Name} | {Immatriculation} | {Modele} | {PrixJournalier}€/jour | {Kilometrage}km";
    }
}