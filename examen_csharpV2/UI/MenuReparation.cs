namespace examen_csharpV2.UI;

using examen_csharpV2.Models;
using examen_csharpV2.Service;

/// <summary>
/// Classe représentant le menu de gestion des réparations.
/// Permet d'afficher et de terminer les réparations des véhicules endommagés.
/// </summary>
public class MenuReparation
{
    /// <summary>
    /// Affiche le menu des réparations et gère la navigation.
    /// La boucle continue jusqu'à ce que l'utilisateur choisisse de revenir (0).
    /// </summary>
    public void Afficher()
    {
        bool continuer = true;

        while (continuer)
        {
            Console.WriteLine("\n=== MENU RÉPARATIONS ===");
            Console.WriteLine("1. Afficher toutes les réparations");
            Console.WriteLine("2. Terminer une réparation");
            Console.WriteLine("0. Retour");
            Console.Write("Votre choix : ");

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    AfficherReparation();
                    break;
                case "2":
                    TerminerReparation();
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
    /// Affiche la liste de toutes les réparations enregistrées dans le DataStore.
    /// Utilise la méthode ToString() de chaque réparation pour l'affichage.
    /// </summary>
    private void AfficherReparation()
    {
        Console.WriteLine("\n=== LISTE DES RÉPARATIONS ===");

        if (DataStore.Reparation.Count == 0)
        {
            Console.WriteLine("Aucune réparation enregistrée.");
            return;
        }

        for (int i = 0; i < DataStore.Reparation.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {DataStore.Reparation[i]}");
        }
    }

    /// <summary>
    /// Permet de terminer une réparation en cours.
    /// Une fois la réparation terminée, le véhicule redevient automatiquement disponible.
    /// Filtre uniquement les réparations en cours pour l'affichage.
    /// </summary>
    private void TerminerReparation()
    {
        Console.WriteLine("\n=== TERMINER UNE RÉPARATION ===");

        // Filtrer uniquement les réparations en cours
        List<Reparation> reparationsEnCours = new List<Reparation>();
        for (int i = 0; i < DataStore.Reparation.Count; i++)
        {
            if (!DataStore.Reparation[i].EstTermine)
            {
                reparationsEnCours.Add(DataStore.Reparation[i]);
                Console.WriteLine($"{reparationsEnCours.Count}. {DataStore.Reparation[i]}");
            }
        }

        if (reparationsEnCours.Count == 0)
        {
            Console.WriteLine("Aucune réparation en cours !");
            return;
        }

        Console.Write("Choisissez la réparation à terminer (numéro) : ");
        string saisie = Console.ReadLine();
        if (saisie == "0") return;

        if (!int.TryParse(saisie, out int index))
        {
            Console.WriteLine("Entrée invalide !");
            return;
        }

        index -= 1;
        if (index < 0 || index >= reparationsEnCours.Count)
        {
            Console.WriteLine("Numéro invalide !");
            return;
        }

        // Terminer la réparation et remettre le véhicule disponible
        Reparation reparation = reparationsEnCours[index];
        reparation.EstTermine = true;
        reparation.Vehicule.EstDisponible = true;
        Console.WriteLine($"Réparation terminée ! Véhicule {reparation.Vehicule.Modele} remis disponible.");
    }
}