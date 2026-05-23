namespace examen_csharpV2.Models;

public class Reparation
{
    public Vehicule Vehicule { get; set; }
    public string Description { get; set; }
    public DateTime DateDbut { get; set; }
    public int NbJours { get; set; }
    public bool EstTermine { get; set; }

    public Reparation(Vehicule vehicule, string description, int nbJours)
    {
        Vehicule = vehicule;
        Description = description;
        NbJours = nbJours;
        DateDbut = DateTime.Now;
        EstTermine = false;
    }
    
    public override string ToString()
    {
        string statut = EstTermine ? "Termine" : "En cours";
        return  $"{Vehicule.GetType().Name} {Vehicule.Immatriculation} | {Description} | {NbJours} jours | {statut} ";
        

    }
}