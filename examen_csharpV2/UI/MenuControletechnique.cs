namespace examen_csharpV2.UI;

using examen_csharpV2.Models;
using examen_csharpV2.Service;


public class MenuControletechnique
{
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


        int index;
        if (!int.TryParse(saisie, out index))
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

        ControleTechnique controle = new ControleTechnique(vehicule, observations, estValide);
        DataStore.ControleTechnique.Add(controle);
        Console.WriteLine(
            $"Contrôle technique ajouté ! Prochain contrôle le : {controle.DateProchainControle.ToShortDateString()}");
    }

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

    private void VerifierControles()
    {
        Console.WriteLine("\n=== CONTRÔLES À RENOUVELER ===");
        bool found = false;

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
