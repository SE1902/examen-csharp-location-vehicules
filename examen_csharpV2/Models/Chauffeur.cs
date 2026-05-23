namespace examen_csharpV2.Models;

public class Chauffeur
{
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public bool EstDisponible { get; set; }
    public string Raisonindisponibilite { get; set; }
    
    public Chauffeur(string nom, string prenom)
        {
        Nom = nom;
        Prenom = prenom;
        EstDisponible = true;
        Raisonindisponibilite = "";
        }

    public override string ToString()
    {
        if (EstDisponible)
            return $"{Nom} {Prenom} | Disponible";
        else
            return $"{Nom} {Prenom} | Indisponible ({Raisonindisponibilite})";
    }
}