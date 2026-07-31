namespace examen_csharpV2.UI;

using examen_csharpV2.Models;
using examen_csharpV2.Service;

/// <summary>
/// Classe représentant le menu de gestion des contrôles techniques.
/// Permet d'ajouter, afficher et vérifier les contrôles techniques des véhicules.
/// </summary>
public class MenuControletechnique
{
    /// <summary>
    /// Affiche le menu des contrôles techniques et gère la navigation.
    /// La boucle continue jusqu'à ce que l'utilisateur choisisse de revenir (0).
    /// </summary>
    public void Afficher()
    {
        bool continuer = true;

        while (continuer)
        {
            Console.WriteLine("\n=== MENU CONTRÔLES TECHNIQUES ===");
            Console.WriteLine("1. Ajouter un contrôle technique");
            Console.WriteLine("2. Afficher tous les contrôles techniques");
            Console.WriteLine("3. Vérifier les contrôles à renouveler");
            Console.WriteLine("0. Retour");
            Console.Write("Votre choix : ");

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    AjouterControle();
                    break;
                case "2":
                    AfficherControles();
                    break;
                case "3":
                    VerifierControles();
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
    /// Permet d'ajouter un nouveau contrôle technique pour un véhicule.
    /// Le prochain contrôle est automatiquement planifié 2 ans après.
    /// Demande les observations et si le contrôle est valide ou non.
    /// </summary>
    private void AjouterControle()
    {
        Console.WriteLine("\n=== AJOUTER UN CONTRÔLE TECHNIQUE ===");

        if (DataStore.Vehicules.Count == 0)
        {
            Console.WriteLine("Aucun véhicule enregistré !");
            return;
        }

        for (int i = 0; i < DataStore.Vehicules.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {DataStore.Vehicules[i]}");
        }

        Console.Write("Choisissez un véhicule (numéro) : ");
        string saisie = Console.ReadLine();
        if (saisie == "0") return;

        if (!int.TryParse(saisie, out int index))
        {
            Console.WriteLine("Entrée invalide !");
            return;
        }

        index -= 1;
        if (index < 0 || index >= DataStore.Vehicules.Count)
        {
            Console.WriteLine("Numéro invalide !");
            return;
        }

        Vehicule vehicule = DataStore.Vehicules[index];

        Console.Write("Observations : ");
        string observations = Console.ReadLine();

        Console.Write("Contrôle valide ? (oui/non) : ");
        string reponse = Console.ReadLine().ToLower();
        bool estValide = reponse == "oui";

        // Créer le contrôle et planifier automatiquement le prochain dans 2 ans
        ControleTechnique controle = new ControleTechnique(vehicule, observations, estValide);
        DataStore.ControleTechnique.Add(controle);
        Console.WriteLine($"Contrôle technique ajouté ! Prochain contrôle le : {controle.DateProchainControle.ToShortDateString()}");
    }

    /// <summary>
    /// Affiche la liste de tous les contrôles techniques enregistrés dans le DataStore.
    /// Utilise la méthode ToString() de chaque contrôle pour l'affichage.
    /// </summary>
    private void AfficherControles()
    {
        Console.WriteLine("\n=== LISTE DES CONTRÔLES TECHNIQUES ===");

        if (DataStore.ControleTechnique.Count == 0)
        {
            Console.WriteLine("Aucun contrôle technique enregistré.");
            return;
        }

        for (int i = 0; i < DataStore.ControleTechnique.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {DataStore.ControleTechnique[i]}");
        }
    }

    /// <summary>
    /// Vérifie les contrôles techniques à renouveler dans le prochain mois.
    /// Affiche une alerte pour chaque véhicule dont le contrôle expire bientôt.
    /// </summary>
    private void VerifierControles()
    {
        Console.WriteLine("\n=== CONTRÔLES À RENOUVELER ===");
        bool found = false;

        // Vérifier si le prochain contrôle est dans moins d'un mois
        foreach (var controle in DataStore.ControleTechnique)
        {
            if (controle.DateProchainControle <= DateTime.Now.AddMonths(1))
            {
                Console.WriteLine($"⚠️ {controle}");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Aucun contrôle à renouveler dans le prochain mois !");
        }
    }
}