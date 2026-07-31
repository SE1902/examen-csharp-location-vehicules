namespace examen_csharpV2.UI;

using examen_csharpV2.Models;
using examen_csharpV2.Service;

/// <summary>
/// Classe représentant le menu de gestion des véhicules.
/// Permet d'ajouter, afficher, supprimer et modifier les véhicules de l'agence.
/// </summary>
public class MenuVehicule
{
    /// <summary>
    /// Affiche le menu des véhicules et gère la navigation.
    /// La boucle continue jusqu'à ce que l'utilisateur choisisse de revenir (0).
    /// </summary>
    public void Afficher()
    {
        bool continuer = true;

        while (continuer)
        {
            Console.WriteLine("\n=== MENU VEHICULES ===");
            Console.WriteLine("1. Ajouter un véhicule");
            Console.WriteLine("2. Afficher tous les véhicules");
            Console.WriteLine("3. Supprimer un véhicule");
            Console.WriteLine("4. Modifier un véhicule");
            Console.WriteLine("0. Retour");
            Console.Write("Votre choix : ");

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    AjouterVehicule();
                    break;
                case "2":
                    AfficherVehicules();
                    break;
                case "3":
                    SupprimerVehicule();
                    break;
                case "4":
                    ModifierVehicule();
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
    /// Permet d'ajouter un nouveau véhicule dans le DataStore.
    /// Demande le type de véhicule et ses informations spécifiques.
    /// Utilise TryParse pour valider les entrées numériques.
    /// </summary>
    private void AjouterVehicule()
    {
        Console.WriteLine("\n=== AJOUTER UN VEHICULE ===");
        Console.WriteLine("Type de véhicule :");
        Console.WriteLine("1. Voiture");
        Console.WriteLine("2. Moto");
        Console.WriteLine("3. Vélomoteur");
        Console.WriteLine("4. Camion");
        Console.WriteLine("5. Mobil Home");
        Console.WriteLine("6. Limousine");
        Console.WriteLine("7. Autobus");
        Console.Write("Votre choix (0 pour annuler) : ");

        string choixType = Console.ReadLine();
        if (choixType == "0") return;

        Console.Write("Immatriculation (0 pour annuler) : ");
        string immatriculation = Console.ReadLine();
        if (immatriculation == "0") return;

        Console.Write("Modele (0 pour annuler) : ");
        string modele = Console.ReadLine();
        if (modele == "0") return;

        Console.Write("Prix journalier (0 pour annuler) : ");
        string prixInput = Console.ReadLine();
        if (prixInput == "0") return;
        if (!double.TryParse(prixInput, out double prix))
        {
            Console.WriteLine("Prix invalide !");
            return;
        }

        Console.Write("Kilométrage (0 pour annuler) : ");
        string kmInput = Console.ReadLine();
        if (kmInput == "0") return;
        if (!double.TryParse(kmInput, out double km))
        {
            Console.WriteLine("Kilométrage invalide !");
            return;
        }

        Vehicule vehicule = null;

        switch (choixType)
        {
            case "1":
                vehicule = new Voiture(immatriculation, modele, prix, km);
                break;
            case "2":
                Console.Write("Cylindrée (cc) : ");
                if (!int.TryParse(Console.ReadLine(), out int cylindreeMoto))
                {
                    Console.WriteLine("Cylindrée invalide !");
                    return;
                }
                vehicule = new Moto(immatriculation, modele, prix, km, cylindreeMoto);
                break;
            case "3":
                Console.Write("Cylindrée (cc) : ");
                if (!int.TryParse(Console.ReadLine(), out int cylindreeVelo))
                {
                    Console.WriteLine("Cylindrée invalide !");
                    return;
                }
                vehicule = new Velomoteur(immatriculation, modele, prix, km, cylindreeVelo);
                break;
            case "4":
                Console.Write("PTAC (tonnes) : ");
                if (!double.TryParse(Console.ReadLine(), out double ptac))
                {
                    Console.WriteLine("PTAC invalide !");
                    return;
                }
                vehicule = new Camion(immatriculation, modele, prix, km, ptac);
                break;
            case "5":
                Console.Write("Nombre de couchages : ");
                if (!int.TryParse(Console.ReadLine(), out int nbCouchages))
                {
                    Console.WriteLine("Nombre invalide !");
                    return;
                }
                vehicule = new MobilHome(immatriculation, modele, prix, km, nbCouchages);
                break;
            case "6":
                Console.Write("Nombre de passagers : ");
                if (!int.TryParse(Console.ReadLine(), out int nbPassagers))
                {
                    Console.WriteLine("Nombre invalide !");
                    return;
                }
                vehicule = new Limousine(immatriculation, modele, prix, km, nbPassagers);
                break;
            case "7":
                Console.Write("Nombre de places : ");
                if (!int.TryParse(Console.ReadLine(), out int nbPlaces))
                {
                    Console.WriteLine("Nombre invalide !");
                    return;
                }
                vehicule = new Autobus(immatriculation, modele, prix, km, nbPlaces);
                break;
            default:
                Console.WriteLine("Type invalide !");
                return;
        }

        DataStore.Vehicules.Add(vehicule);
        Console.WriteLine($"Véhicule {vehicule.Modele} ajouté avec succès !");
    }

    /// <summary>
    /// Affiche la liste de tous les véhicules enregistrés dans le DataStore.
    /// Utilise la méthode ToString() de chaque véhicule pour l'affichage.
    /// </summary>
    private void AfficherVehicules()
    {
        Console.WriteLine("\n=== LISTE DES VEHICULES ===");

        if (DataStore.Vehicules.Count == 0)
        {
            Console.WriteLine("Aucun véhicule enregistré.");
            return;
        }

        for (int i = 0; i < DataStore.Vehicules.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {DataStore.Vehicules[i]}");
        }
    }

    /// <summary>
    /// Permet de supprimer un véhicule du DataStore.
    /// Affiche la liste des véhicules et demande le numéro à supprimer.
    /// Utilise TryParse pour valider l'entrée.
    /// </summary>
    private void SupprimerVehicule()
    {
        Console.WriteLine("\n=== SUPPRIMER UN VEHICULE ===");

        if (DataStore.Vehicules.Count == 0)
        {
            Console.WriteLine("Aucun véhicule enregistré.");
            return;
        }

        for (int i = 0; i < DataStore.Vehicules.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {DataStore.Vehicules[i]}");
        }

        Console.Write("Choisissez un véhicule (numéro) : ");
        string saisie = Console.ReadLine();

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
        DataStore.Vehicules.RemoveAt(index);
        Console.WriteLine($"Véhicule {vehicule.Modele} supprimé avec succès !");
    }

    /// <summary>
    /// Permet de modifier les informations d'un véhicule existant.
    /// L'utilisateur peut modifier le modèle, le prix journalier et le kilométrage.
    /// Appuyer sur Enter sans saisir de valeur conserve la valeur actuelle.
    /// </summary>
    private void ModifierVehicule()
    {
        Console.WriteLine("\n=== MODIFIER UN VEHICULE ===");

        if (DataStore.Vehicules.Count == 0)
        {
            Console.WriteLine("Aucun véhicule enregistré.");
            return;
        }

        for (int i = 0; i < DataStore.Vehicules.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {DataStore.Vehicules[i]}");
        }

        Console.Write("Choisissez un véhicule à modifier (numéro) : ");
        string saisie = Console.ReadLine();

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

        Console.WriteLine($"Modèle actuel : {vehicule.Modele}");
        Console.Write("Nouveau modèle (Enter pour garder) : ");
        string nouveauModele = Console.ReadLine();
        if (nouveauModele != "") vehicule.Modele = nouveauModele;

        Console.WriteLine($"Prix journalier actuel : {vehicule.PrixJournalier}€");
        Console.Write("Nouveau prix (Enter pour garder) : ");
        string nouveauPrix = Console.ReadLine();
        if (nouveauPrix != "")
        {
            if (!double.TryParse(nouveauPrix, out double prix))
            {
                Console.WriteLine("Prix invalide !");
                return;
            }
            vehicule.PrixJournalier = prix;
        }

        Console.WriteLine($"Kilométrage actuel : {vehicule.Kilometrage}km");
        Console.Write("Nouveau kilométrage (Enter pour garder) : ");
        string nouveauKm = Console.ReadLine();
        if (nouveauKm != "")
        {
            if (!double.TryParse(nouveauKm, out double km))
            {
                Console.WriteLine("Kilométrage invalide !");
                return;
            }
            vehicule.Kilometrage = km;
        }

        Console.WriteLine($"Véhicule modifié avec succès ! {vehicule}");
    }
}