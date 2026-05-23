namespace examen_csharpV2.UI;

using examen_csharpV2.Models;
using examen_csharpV2.Service;

public class MenuFormation
{
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

        Console.WriteLine("Type de permis visé :");
        Console.WriteLine("1. Permis A");
        Console.WriteLine("2. Permis B");
        Console.WriteLine("3. Permis C");
        Console.WriteLine("4. Permis D");
        Console.Write("Votre choix : ");
        
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
        int nbJours;
        if (!int.TryParse(Console.ReadLine(), out nbJours))
        {
            Console.WriteLine("Nombre invalide !");
            return;
        }
        Formation formation = new Formation(client, typePermis, nbJours);
        DataStore.Formation.Add(formation);
        Console.WriteLine($"Formation pour le permis {typePermis} ajoutée avec succès !");
    }

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

    private void TerminerFormation()
    {
        Console.WriteLine("\n=== TERMINER UNE FORMATION ===");

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
        
        int index;
        if (!int.TryParse(saisie, out index))
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
        if (!formation.Client.Permis.Contains(formation.TypePermis))
        {
            formation.Client.Permis.Add(formation.TypePermis);
        }
        Console.WriteLine($"Formation terminée ! {formation.Client.Nom} {formation.Client.Prenom} a maintenant le permis {formation.TypePermis} !");
    }
}

    
    