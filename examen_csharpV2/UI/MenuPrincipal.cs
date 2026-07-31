namespace examen_csharpV2.UI;

/// <summary>
/// Classe représentant le menu principal de l'application.
/// Point d'entrée de l'interface utilisateur qui regroupe tous les sous-menus.
/// </summary>
public class MenuPrincipal
{
    /// <summary>Menu de gestion des véhicules</summary>
    private MenuVehicule _menuVehicule = new MenuVehicule();
    
    /// <summary>Menu de gestion des clients</summary>
    private MenuClient _menuClient = new MenuClient();
    
    /// <summary>Menu de gestion des chauffeurs</summary>
    private MenuChauffeur _menuChauffeur = new MenuChauffeur();
    
    /// <summary>Menu de gestion des locations</summary>
    private MenuLocation _menuLocation = new MenuLocation();
    
    /// <summary>Menu de gestion des réparations</summary>
    private MenuReparation _menuReparation = new MenuReparation();
    
    /// <summary>Menu de gestion des contrôles techniques</summary>
    private MenuControletechnique _menuControleTechnique = new MenuControletechnique();
    
    /// <summary>Menu de gestion des formations</summary>
    private MenuFormation _menuFormation = new MenuFormation();

    /// <summary>
    /// Affiche le menu principal et gère la navigation vers les sous-menus.
    /// Utilise un switch pour rediriger vers le bon menu selon le choix de l'utilisateur.
    /// La boucle continue jusqu'à ce que l'utilisateur choisisse de quitter (0).
    /// </summary>
    public void Afficher()
    {
        bool continuer = true;

        while (continuer)
        {
            Console.WriteLine("\n=== MENU PRINCIPAL ===");
            Console.WriteLine("1. Gérer les véhicules");
            Console.WriteLine("2. Gérer les clients");
            Console.WriteLine("3. Gérer les chauffeurs");
            Console.WriteLine("4. Gérer les locations");
            Console.WriteLine("5. Gérer les réparations");
            Console.WriteLine("6. Gérer les contrôles techniques");
            Console.WriteLine("7. Gérer les formations");
            Console.WriteLine("0. Quitter");
            Console.Write("Votre choix : ");
            
            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    _menuVehicule.Afficher();
                    break;
                case "2":
                    _menuClient.Afficher();
                    break;
                case "3":
                    _menuChauffeur.Afficher();
                    break;
                case "4":
                    _menuLocation.Afficher();
                    break;
                case "5":
                    _menuReparation.Afficher();
                    break;
                case "6":
                    _menuControleTechnique.Afficher();
                    break;
                case "7":
                    _menuFormation.Afficher();
                    break;
                case "0":
                    continuer = false;
                    Console.WriteLine("Au revoir !");
                    break;
                default:
                    Console.WriteLine("Option invalide !");
                    break;
            }
        }
    }
}