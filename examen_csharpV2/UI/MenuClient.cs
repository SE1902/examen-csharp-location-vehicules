namespace examen_csharpV2.UI;

using examen_csharpV2.Service;
using examen_csharpV2.Models;

/// <summary>
/// Classe représentant le menu de gestion des clients.
/// Permet d'ajouter, afficher, supprimer et modifier les clients de l'agence.
/// </summary>
public class MenuClient
{
    /// <summary>
    /// Affiche le menu des clients et gère la navigation.
    /// La boucle continue jusqu'à ce que l'utilisateur choisisse de revenir (0).
    /// </summary>
    public void Afficher()
    {
        bool continuer = true;
        
        while (continuer)
        {
            Console.WriteLine("\n=== MENU CLIENTS ===");
            Console.WriteLine("1. Ajouter un client");
            Console.WriteLine("2. Afficher un client");
            Console.WriteLine("3. Supprimer un client");
            Console.WriteLine("4. Modifier un client");
            Console.WriteLine("0. Retour");
            Console.WriteLine("Votre choix");
            
            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    AjouterClient();
                    break;
                case "2":
                    AfficherClients();
                    break;
                case "3":
                    SupprimerClient();
                    break;
                case "4":
                    ModifierClient();
                    break;
                case "0":
                    continuer = false;
                    break;
                default:
                    Console.WriteLine("Option invalide");
                    break;
            }
        }    
    }

    /// <summary>
    /// Permet d'ajouter un nouveau client dans le DataStore.
    /// Demande le nom, prénom et le type de permis du client.
    /// Utilise un switch expression pour convertir le choix en type de permis.
    /// </summary>
    private void AjouterClient()
    {
        Console.WriteLine("\n=== AJOUTER UN CLIENT ===");
        
        Console.Write("Nom (0 pour annuler) : ");
        string nom = Console.ReadLine();
        if (nom == "0") return;
        
        Console.Write("Prénom (0 pour annuler) : ");
        string prenom = Console.ReadLine();
        if (prenom == "0") return;
        
        Console.WriteLine("Type de permis :");
        Console.WriteLine("1. Permis A");
        Console.WriteLine("2. Permis B");
        Console.WriteLine("3. Permis C");
        Console.WriteLine("4. Permis D");
        Console.WriteLine("5. Aucun permis");
        Console.WriteLine("Votre choix : ");
        
        string choixPermis = Console.ReadLine();

        string numPermis = choixPermis switch
        {
            "1" => "A",
            "2" => "B",
            "3" => "C",
            "4" => "D",
            "5" => "Aucun",
            _ => "Aucun"
        };
        
        Client client = new Client(nom, prenom, numPermis);
        DataStore.Clients.Add(client);
        Console.WriteLine($"Client {nom} {prenom} ajouté avec succès !");
    } 

    /// <summary>
    /// Affiche la liste de tous les clients enregistrés dans le DataStore.
    /// Utilise la méthode ToString() de chaque client pour l'affichage.
    /// </summary>
    private void AfficherClients()
    {
        Console.WriteLine("\n=== LISTE DES CLIENTS ===");

        if (DataStore.Clients.Count == 0)
        {
            Console.WriteLine("Aucun client enregistré");
            return;
        }

        foreach (var client in DataStore.Clients)
        {
            Console.WriteLine(client.ToString());
        }
    }

    /// <summary>
    /// Permet de supprimer un client du DataStore.
    /// Affiche la liste des clients et demande le numéro à supprimer.
    /// Utilise TryParse pour valider l'entrée.
    /// </summary>
    private void SupprimerClient()
    {
        Console.WriteLine("\n=== SUPPRIMER UN CLIENT ===");

        if (DataStore.Clients.Count == 0)
        {
            Console.WriteLine("Aucun client enregistré.");
            return;
        }

        for (int i = 0; i < DataStore.Clients.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {DataStore.Clients[i]}");
        }

        Console.Write("Choisissez un client (numéro) : ");
        string saisie = Console.ReadLine();

        if (!int.TryParse(saisie, out int index))
        {
            Console.WriteLine("Entrée invalide !");
            return;
        }

        index -= 1;

        if (index < 0 || index >= DataStore.Clients.Count)
        {
            Console.WriteLine("Numero invalide !");
            return;
        }

        Client client = DataStore.Clients[index];
        DataStore.Clients.RemoveAt(index);
        Console.WriteLine($"Client {client.Nom} {client.Prenom} supprimé avec succès !");
    }
    
    /// <summary>
    /// Permet de modifier les informations d'un client existant.
    /// L'utilisateur peut modifier le nom et le prénom.
    /// Appuyer sur Enter sans saisir de valeur conserve la valeur actuelle.
    /// </summary>
    private void ModifierClient()
    {
        Console.WriteLine("\n=== MODIFIER UN CLIENT ===");

        if (DataStore.Clients.Count == 0)
        {
            Console.WriteLine("Aucun client enregistré.");
            return;
        }

        for (int i = 0; i < DataStore.Clients.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {DataStore.Clients[i]}");
        }

        Console.Write("Choisissez un client à modifier (numéro) : ");
        string saisie = Console.ReadLine();

        if (!int.TryParse(saisie, out int index))
        {
            Console.WriteLine("Entrée invalide !");
            return;
        }
        index -= 1;
        if (index < 0 || index >= DataStore.Clients.Count)
        {
            Console.WriteLine("Numéro invalide !");
            return;
        }

        Client client = DataStore.Clients[index];

        Console.WriteLine($"Nom actuel : {client.Nom}");
        Console.Write("Nouveau nom (Enter pour garder) : ");
        string nouveauNom = Console.ReadLine();
        if (nouveauNom != "") client.Nom = nouveauNom;

        Console.WriteLine($"Prénom actuel : {client.Prenom}");
        Console.Write("Nouveau prénom (Enter pour garder) : ");
        string nouveauPrenom = Console.ReadLine();
        if (nouveauPrenom != "") client.Prenom = nouveauPrenom;

        Console.WriteLine($"Client modifié avec succès ! {client}");
    }
}