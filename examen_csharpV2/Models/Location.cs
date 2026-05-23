namespace examen_csharpV2.Models;

public class Location
{
    public Client Client { get; set; }
    public Vehicule Vehicule { get; set; }
    public Chauffeur? Chauffeur { get; set; }
    public DateTime Datedebut { get; set; }
    public int NbJours { get; set; }
    public double MontantTotal { get; set; }
    public bool EstTerminee { get; set; }
    
    public Location(Client client, Vehicule vehicule,int nbJours,Chauffeur? chauffeur =  null)
    {
        Client = client;
        Vehicule = vehicule;
        NbJours = nbJours;
        Chauffeur = chauffeur;
        Datedebut = DateTime.Now;
        MontantTotal = vehicule.PrixJournalier * nbJours;
        EstTerminee = false;
    }

    public override string ToString()
    {
        string chauffeur = Chauffeur != null ? $"Chauffeur : {Chauffeur.Nom}" : "Sans chauffeur";
        string statut = EstTerminee ? "Terminée" : "En cours";
        return
            $"{Client.Nom} {Client.Prenom} | {Vehicule.GetType().Name} {Vehicule.Immatriculation}| {NbJours} jours | {MontantTotal} € | {statut}";
    }
}