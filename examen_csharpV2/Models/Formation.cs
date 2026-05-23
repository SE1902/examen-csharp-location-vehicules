namespace examen_csharpV2.Models;

public class Formation
{
    public Client Client { get; set; }
    public string TypePermis {get; set;}
    public DateTime DateDebut { get; set; }
    public int NbJours { get; set; }
    public bool EstTerminee { get; set; }

    public Formation(Client client, string typePermis, int nbJours)
    {
        Client = client;
        TypePermis = typePermis;
        NbJours = nbJours;
        DateDebut = DateTime.Now;
        EstTerminee = false;
    }

    public override string ToString()
    {
        string statut = EstTerminee ? "Terminée" : "En cours";
        return $"{Client.Nom} {Client.Prenom} | Permis {TypePermis} | {NbJours} jours | {statut}";
    }
}