namespace examen_csharpV2.UI;

using examen_csharpV2.Models;
using examen_csharpV2.Service;

/// <summary>
/// Classe représentant le menu de gestion des formations de conduite.
/// Permet d'inscrire des clients à des formations et de gérer l'obtention des permis.
/// </summary>
public class MenuFormation
{
    /// <summary>
    /// Affiche le menu des formations et gère la navigation.
    /// La boucle continue jusqu'à ce que l'utilisateur choisisse de revenir (0).
    /// </summary>
    public void Afficher()
    {
        bool continuer = true;

        while (continuer)
        {
            Console.WriteLine("\n=== MENU FORMATIONS ===");
            Console.WriteLine("1. Inscrire un client à une formation");
            Console.WriteLine("2. Afficher toutes les formations");
            Console.WriteLine("3. Terminer une formation");
            Console.WriteLine("0. Retour");
            Console.Write("Votre choix : ");
            
            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    AjouterFormation();
                    break;
                case "2":
                    AfficherFormations();
                    break;
                case "3":
                    TerminerFormation();
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

    /// <summary>
    /// Permet d'inscrire un client à une formation de conduite.
    /// Demande le type de permis visé et le nombre de jours de formation.
    /// Utilise un switch expression pour convertir le choix en type de permis.
    /// </summary>
    private void AjouterFormation()
    {
        Console.WriteLine("\n=== INSCRIRE À UNE FORMATION ===");
        if (DataStore.Clients.Count == 0)
        {
            Console.WriteLine("Aucun client enregistré !");
            return;
        }
        
        for (int i = 0; i < DataStore.Clients.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {DataStore.Clients[i]}");
        }
        
        Console.Write("Choisissez un client (numéro) : ");
        string saisie = Console.ReadLine();
        if (saisie == "0") return;
        
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

        Console.WriteLine("Type de permis visé :");
        Console.WriteLine("1. Permis A");
        Console.WriteLine("2. Permis B");
        Console.WriteLine("3. Permis C");
        Console.WriteLine("4. Permis D");
        Console.Write("Votre choix : ");
        
        // Switch expression pour convertir le choix en type de permis
        string choixPermis = Console.ReadLine();
        string typePermis = choixPermis switch
        {
            "1" => "A",
            "2" => "B",
            "3" => "C",
            "4" => "D",
            _ => "B"
        };
        
        Console.Write("Nombre de jours de formation : ");
        if (!int.TryParse(Console.ReadLine(), out int nbJours))
        {
            Console.WriteLine("Nombre invalide !");
            return;
        }

        Formation formation = new Formation(client, typePermis, nbJours);
        DataStore.Formation.Add(formation);
        Console.WriteLine($"Formation pour le permis {typePermis} ajoutée avec succès !");
    }

    /// <summary>
    /// Affiche la liste de toutes les formations enregistrées dans le DataStore.
    /// Utilise la méthode ToString() de chaque formation pour l'affichage.
    /// </summary>
    private void AfficherFormations()
    {
        Console.WriteLine("\n=== LISTE DES FORMATIONS ===");

        if (DataStore.Formation.Count == 0)
        {
            Console.WriteLine("Aucune formation enregistrée.");
            return;
        }

        for (int i = 0; i < DataStore.Formation.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {DataStore.Formation[i]}");
        }
    }

    /// <summary>
    /// Permet de terminer une formation en cours.
    /// Une fois la formation terminée, le permis est automatiquement ajouté
    /// à la liste des permis du client s'il ne l'a pas déjà.
    /// </summary>
    private void TerminerFormation()
    {
        Console.WriteLine("\n=== TERMINER UNE FORMATION ===");

        // Filtrer uniquement les formations en cours
        List<Formation> formationsEnCours = new List<Formation>();
        for (int i = 0; i < DataStore.Formation.Count; i++)
        {
            if (!DataStore.Formation[i].EstTerminee)
            {
                formationsEnCours.Add(DataStore.Formation[i]);
                Console.WriteLine($"{formationsEnCours.Count}. {DataStore.Formation[i]}");
            }
        }
    
        if (formationsEnCours.Count == 0)
        {
            Console.WriteLine("Aucune formation en cours !");
            return;
        }
        
        Console.Write("Choisissez la formation à terminer (numéro) : ");
        string saisie = Console.ReadLine();
        if (saisie == "0") return;
        
        if (!int.TryParse(saisie, out int index))
        {
            Console.WriteLine("Entrée invalide !");
            return;
        }
        index -= 1;
        if (index < 0 || index >= formationsEnCours.Count)
        {
            Console.WriteLine("Numéro invalide !");
            return;
        }
        
        Formation formation = formationsEnCours[index];
        formation.EstTerminee = true;

        // Ajouter le permis au client s'il ne l'a pas déjà
        if (!formation.Client.Permis.Contains(formation.TypePermis))
        {
            formation.Client.Permis.Add(formation.TypePermis);
        }
        Console.WriteLine($"Formation terminée ! {formation.Client.Nom} {formation.Client.Prenom} a maintenant le permis {formation.TypePermis} !");
    }
}