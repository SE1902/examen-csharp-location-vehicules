namespace examen_csharpV2.UI;

using examen_csharpV2.Models;
using examen_csharpV2.Service;


public class MenuChauffeur
{
    public void Afficher()
    {
        bool continuer = true;

        while (continuer)
        {
            Console.WriteLine("\n=== MENU CHAUFFEUR ===");
            Console.WriteLine("1. Ajouter un chauffeur");
            Console.WriteLine("2. Afficher tout les chauffeurs");
            Console.WriteLine("3. Supprimer un chauffeur");
            Console.WriteLine("4. Mettre en congé / maladie");
            Console.WriteLine("5. Remettre disponible");
            Console.WriteLine("0. Retour");
            Console.Write("Votre choix : ");

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    AjouterChauffeur();
                break;
                case "2":
                    AfficherChauffeur();
                break;
                case "3":
                    SupprimerChauffeur();
                break;
                case "4":
                    ChangerDisponibilite(false);
                break;
                case "5":
                    ChangerDisponibilite(true);
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

    private void AjouterChauffeur()
    {
        Console.WriteLine("\n=== AJOUTER UN CHAUFFEUR ===");
        
        Console.Write("Nom(0 pour annuler) : ");
        string nom = Console.ReadLine();
        if (nom == "0") return;
        
        Console.Write("prenom(0 pour annuler) : ");
        string prenom = Console.ReadLine();
        if (prenom == "0") return;
        
        Chauffeur chauffeur = new Chauffeur(nom, prenom);
        DataStore.Chauffeurs.Add(chauffeur);
        Console.WriteLine($"Chauffeur {nom} {prenom} ajouté avec succès !");
    }

    public void AfficherChauffeur()
    {
        Console.WriteLine("\n=== AFFICHER UN CHAUFFEUR ===");
        if (DataStore.Chauffeurs.Count == 0)
        {
            Console.WriteLine("Aucun chauffeur enregistré.");
            return;
        }

        for (int i = 0; i < DataStore.Chauffeurs.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {DataStore.Chauffeurs[i]}");
        }
    }

    private void SupprimerChauffeur()
    {
        Console.WriteLine("\n=== SUPPRIMER UN CHAUFFEUR ===");
        if (DataStore.Chauffeurs.Count == 0)
        {
            Console.WriteLine("Aucun chauffeur enregistré.");
            return;
        }

        for (int i = 0; i < DataStore.Chauffeurs.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {DataStore.Chauffeurs[i]}");
        }
        
        Console.WriteLine("Choisissez un chauffeur (numéro) : ");
        string saisie = Console.ReadLine();
        
        if (!int.TryParse(saisie, out int index))
        {
            Console.WriteLine("Entrée invalide !");
            return;
        }

        index -= 1;
        
        if (index < 0 || index >= DataStore.Chauffeurs.Count)
        {
            Console.WriteLine("Numero invalide");
            return;
        }
        
        Chauffeur chauffeur = DataStore.Chauffeurs[index];
        DataStore.Chauffeurs.RemoveAt(index);
        Console.WriteLine($"Chauffeur {chauffeur.Nom} {chauffeur.Prenom} supprimé avec succès !");
    }
    
    private void ChangerDisponibilite(bool disponible)
    {
        Console.WriteLine(disponible ? "\n=== REMETTRE DISPONIBLE ===" : "\n=== METTRE EN CONGÉ / MALADIE ===");

        if (DataStore.Chauffeurs.Count == 0)
        {
            Console.WriteLine("Aucun chauffeur enregistré.");
            return;
        }
        
        for (int i = 0; i < DataStore.Chauffeurs.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {DataStore.Chauffeurs[i]}");
            
        }

        Console.WriteLine("Choisissez un chauffeur (numéro) : ");
        string saisie = Console.ReadLine();
        
        if (!int.TryParse(saisie, out int index))
        {
            Console.WriteLine("Entrée invalide !");
            return;
        }
        
        index -= 1;
        if (index < 0 || index >= DataStore.Chauffeurs.Count)
        {
            Console.WriteLine("Numero invalide !");
            return;
        }
        
        Chauffeur chauffeur = DataStore.Chauffeurs[index];
        chauffeur.EstDisponible = disponible;

        if (!disponible)
        {
            Console.Write("Raison ( Congé / Maladie) : ");
            chauffeur.Raisonindisponibilite = Console.ReadLine();
        }

        else
        {
            chauffeur.Raisonindisponibilite = "";
        }

        Console.WriteLine($"Statut de {chauffeur.Nom} {chauffeur.Prenom} mis à jour !");
        
    }
}