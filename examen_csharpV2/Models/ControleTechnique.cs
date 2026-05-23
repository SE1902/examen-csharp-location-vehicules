namespace examen_csharpV2.Models;

public class ControleTechnique
{
    public Vehicule Vehicule { get; set; }
    public DateTime DateControle { get; set; }
    public DateTime DateProchainControle { get; set; }
    public bool EstValide { get; set; }
    public string Observations { get; set; }

    public ControleTechnique(Vehicule vehicule, string observations, bool estValide)
    {
        Vehicule = vehicule;
        Observations = observations;
        EstValide = estValide;
        DateControle = DateTime.Now;
        DateProchainControle = DateTime.Now.AddYears(2);
    }

    public override string ToString()
    {
        string valide = EstValide ? "Valide" : "Non valide"; // if/else raccourci en 1 ligne 
        return $"{Vehicule.GetType().Name} {Vehicule.Immatriculation} | Contrôlé le : {DateControle.ToShortDateString()} | Prochain  : {DateProchainControle.ToShortDateString()} | {valide} | {Observations}";
    }
}