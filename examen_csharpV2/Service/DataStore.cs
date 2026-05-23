namespace examen_csharpV2.Service;

using examen_csharpV2.Models;

public static class DataStore
{
    public static List<Vehicule> Vehicules { get; set; } = new List<Vehicule>();
    public static List<Client> Clients { get; set; } = new List<Client>();
    public static List<Chauffeur> Chauffeurs { get; set; } = new List<Chauffeur>();
    public static List<Location> Location { get; set; } = new List<Location>();
    public static List<Reparation> Reparation { get; set; } = new List<Reparation>();
    public static List<ControleTechnique> ControleTechnique { get; set; } = new List<ControleTechnique>();
    public static List<Formation> Formation { get; set; } = new List<Formation>();
}