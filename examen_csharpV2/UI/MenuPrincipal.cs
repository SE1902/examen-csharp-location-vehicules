namespace examen_csharpV2.UI;

public class MenuPrincipal
{
    private MenuVehicule _menuVehicule = new MenuVehicule();
    private MenuClient _menuClient = new MenuClient();
    private MenuChauffeur _menuChauffeur = new MenuChauffeur();
    private MenuLocation _menuLocation = new MenuLocation();
    private MenuReparation _menuReparation = new MenuReparation();
    private MenuControletechnique _menuControleTechnique = new MenuControletechnique();
    private MenuFormation _menuFormation = new MenuFormation();

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