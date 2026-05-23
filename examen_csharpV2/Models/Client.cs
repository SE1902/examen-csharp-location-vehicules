namespace examen_csharpV2.Models;

public class Client
{
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public List<string> Permis { get; set; }

    public Client(string nom, string prenom, string numPermis)
    {
        Nom = nom;
        Prenom = prenom;
        Permis = new List<string> { numPermis };
    }
    
    public override string ToString()
    {
        return $"{Nom} {Prenom} | Permis : {string.Join(",", Permis)}";
    }
}