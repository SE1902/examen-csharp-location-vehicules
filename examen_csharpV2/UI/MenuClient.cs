namespace examen_csharpV2.UI;


using examen_csharpV2.Service;
using examen_csharpV2.Models;


public class MenuClient
{
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

    private void AjouterClient()
    {
        Console.WriteLine("\n=== AJOUTER UN CLIENT ===");
        
        Console.Write("nom (0 pour annuler) : ");
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
        
        Client client = new Client(nom,  prenom, numPermis);
        DataStore.Clients.Add(client);
        Console.WriteLine($"Client {nom} {prenom} ajouté avec succès !");
    } 

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

        int index;
        if (!int.TryParse(saisie, out index))
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