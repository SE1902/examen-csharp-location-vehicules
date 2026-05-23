namespace examen_csharpV2.UI;

using examen_csharpV2.Models;
using examen_csharpV2.Service;

public class MenuLocation
{
    public void Afficher()
    {
        bool continuer = true;

        while (continuer)
        {
            Console.WriteLine("\n=== MENU LOCATIONS ===");
            Console.WriteLine("1. Créer une location");
            Console.WriteLine("2. Afficher toutes les locations");
            Console.WriteLine("3. Retourner un véhicule");
            Console.WriteLine("0. Retour");
            Console.Write("Votre choix : ");

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    CreerLocation();
                    break;
                case "2":
                    AfficherLocations();
                    break;
                case "3":
                    RetournerVehicule();
                    break;
                case "0":
                    continuer = false;
                    break;
                default:
                    Console.WriteLine("Option invalide !");
                    break;
            }
        }
    }

    private void CreerLocation()
    {

        Console.WriteLine("\n=== CRÉER UNE LOCATION ===");

            if (DataStore.Clients.Count == 0)
            {
                Console.WriteLine("Aucun client enregistré !");
                return;
            }

            if (DataStore.Vehicules.Count == 0)
            {
                Console.WriteLine("Aucun véhicule enregistré !");
                return;
            }

            // Choisir le client
            Console.WriteLine("\nClients disponibles :");
            for (int i = 0; i < DataStore.Clients.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {DataStore.Clients[i]}");
            }

            Console.Write("Choisissez un client (numéro) : ");
            string saisieClient = Console.ReadLine();
            if (saisieClient == "0") return;

            int indexClient;
            if (!int.TryParse(saisieClient, out indexClient))
            {
                Console.WriteLine("Entrée invalide !");
                return;
            }

            indexClient -= 1;
            if (indexClient < 0 || indexClient >= DataStore.Clients.Count)
            {
                Console.WriteLine("Numéro invalide !");
                return;
            }

            Client client = DataStore.Clients[indexClient];

            // Choisir le véhicule
            Console.WriteLine("\nVéhicules disponibles :");
            List<Vehicule> vehiculesDisponibles = new List<Vehicule>();
            for (int i = 0; i < DataStore.Vehicules.Count; i++)
            {
                if (DataStore.Vehicules[i].EstDisponible)
                {
                    vehiculesDisponibles.Add(DataStore.Vehicules[i]);
                    Console.WriteLine($"{vehiculesDisponibles.Count}. {DataStore.Vehicules[i]}");
                }
            }

            if (vehiculesDisponibles.Count == 0)
            {
                Console.WriteLine("Aucun véhicule disponible !");
                return;
            }

            Console.Write("Choisissez un véhicule (numéro) : ");
            string saisieVehicule = Console.ReadLine();
            if (saisieVehicule == "0") return;

            int indexVehicule;
            if (!int.TryParse(saisieVehicule, out indexVehicule))
            {
                Console.WriteLine("Entrée invalide !");
                return;
            }

            indexVehicule -= 1;
            if (indexVehicule < 0 || indexVehicule >= vehiculesDisponibles.Count)
            {
                Console.WriteLine("Numéro invalide !");
                return;
            }

            Vehicule vehicule = vehiculesDisponibles[indexVehicule];

            // Vérifier le permis
            if (!VerifierPermis(client, vehicule))
            {
                Console.WriteLine(
                    $"Le client n'a pas le permis requis pour ce véhicule ! (Permis requis : {vehicule.PermisRequis})");
                return;
            }

            // Chauffeur obligatoire ?
            Chauffeur chauffeur = null;
            if (vehicule is Limousine || vehicule is Autobus)
            {
                Console.WriteLine("\nCe véhicule nécessite un chauffeur !");

                List<Chauffeur> chauffeursDisponibles = new List<Chauffeur>();
                for (int i = 0; i < DataStore.Chauffeurs.Count; i++)
                {
                    if (DataStore.Chauffeurs[i].EstDisponible)
                    {
                        chauffeursDisponibles.Add(DataStore.Chauffeurs[i]);
                        Console.WriteLine($"{chauffeursDisponibles.Count}. {DataStore.Chauffeurs[i]}");
                    }
                }

                if (chauffeursDisponibles.Count == 0)
                {
                    Console.WriteLine("Aucun chauffeur disponible !");
                    return;
                }

                Console.Write("Choisissez un chauffeur (numéro) : ");
                string saisieChauffeur = Console.ReadLine();
                if (saisieChauffeur == "0") return;

                int indexChauffeur;
                if (!int.TryParse(saisieChauffeur, out indexChauffeur))
                {
                    Console.WriteLine("Entrée invalide !");
                    return;
                }

                indexChauffeur -= 1;
                if (indexChauffeur < 0 || indexChauffeur >= chauffeursDisponibles.Count)
                {
                    Console.WriteLine("Numéro invalide !");
                    return;
                }

                chauffeur = chauffeursDisponibles[indexChauffeur];
                chauffeur.EstDisponible = false;
            }

            // Nombre de jours
            Console.Write("\nNombre de jours : ");
            string saisieJours = Console.ReadLine();
            if (saisieJours == "0") return;

            int nbJours;
            if (!int.TryParse(saisieJours, out nbJours))
            {
                Console.WriteLine("Nombre de jours invalide !");
                return;
            }

            // Créer la location
            Location location = new Location(client, vehicule, nbJours, chauffeur);
            vehicule.EstDisponible = false;
            DataStore.Location.Add(location);

            Console.WriteLine($"\nLocation créée avec succès !");
            Console.WriteLine($"Client : {client.Nom} {client.Prenom}");
            Console.WriteLine($"Véhicule : {vehicule.Modele}");
            Console.WriteLine($"Durée : {nbJours} jours");
            Console.WriteLine($"Montant total : {location.MontantTotal}€");
        
    }

    private void AfficherLocations()
    {
        
        
            Console.WriteLine("\n=== LISTE DES LOCATIONS ===");

            if (DataStore.Location.Count == 0)
            {
                Console.WriteLine("Aucune location enregistrée.");
                return;
            }

            for (int i = 0; i < DataStore.Location.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {DataStore.Location[i]}");
            }
        
        
    }

    private void RetournerVehicule()
    {
        

    Console.WriteLine("\n=== RETOUR DE LOCATION ===");

    List<Location> locationsEnCours = new List<Location>();
    for (int i = 0; i < DataStore.Location.Count; i++)
    {
        if (!DataStore.Location[i].EstTerminee)
        {
            locationsEnCours.Add(DataStore.Location[i]);
            Console.WriteLine($"{locationsEnCours.Count}. {DataStore.Location[i]}");
        }
    }

    if (locationsEnCours.Count == 0)
    {
        Console.WriteLine("Aucune location en cours !");
        return;
    }

    Console.Write("Choisissez la location à terminer (numéro) : ");
    string saisie = Console.ReadLine();
    if (saisie == "0") return;

    int index;
    if (!int.TryParse(saisie, out index))
    {
        Console.WriteLine("Entrée invalide !");
        return;
    }
    index -= 1;
    if (index < 0 || index >= locationsEnCours.Count)
    {
        Console.WriteLine("Numéro invalide !");
        return;
    }

    Location location = locationsEnCours[index];

    Console.Write("Le véhicule est-il endommagé ? (oui/non) : ");
    string reponse = Console.ReadLine().ToLower();

    if (reponse == "oui")
    {
        Console.Write("Description des dégâts : ");
        string description = Console.ReadLine();
        Console.Write("Nombre de jours de réparation estimé : ");
        int nbJours;
        if (!int.TryParse(Console.ReadLine(), out nbJours))
        {
            Console.WriteLine("Nombre invalide !");
            return;
        }
        Reparation reparation = new Reparation(location.Vehicule, description, nbJours);
        DataStore.Reparation.Add(reparation);
        Console.WriteLine("Véhicule envoyé en réparation !");
    }
    else
    {
        location.Vehicule.EstDisponible = true;
        Console.WriteLine("Véhicule remis disponible !");
    }

    if (location.Chauffeur != null)
    {
        location.Chauffeur.EstDisponible = true;
        Console.WriteLine("Chauffeur remis disponible !");
    }

    location.EstTerminee = true;
    Console.WriteLine("Location terminée avec succès !");

    }

    private bool VerifierPermis(Client client, Vehicule vehicule)
    {
        if (vehicule.PermisRequis == null) return true;
    
        foreach (string permis in client.Permis)
        {
            if (vehicule.PermisRequis.Contains(permis)) return true;
        }
    
        return false;
    }
}