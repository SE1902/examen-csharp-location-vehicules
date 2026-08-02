using examen_csharpV2.UI;
using examen_csharpV2.Models;
using examen_csharpV2.Service;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// ============================================
// SCÉNARIO AUTOMATIQUE
// Exécute automatiquement les fonctionnalités principales du programme
// sans nécessiter d'interaction avec les menus
// ============================================
Console.WriteLine("=== SCÉNARIO AUTOMATIQUE ===\n");

// Étape 1 : Ajout des véhicules de différents types dans le DataStore
Console.WriteLine("--- Ajout des véhicules ---");
DataStore.Vehicules.Add(new Voiture("1-ABC-123", "Renault Clio", 45, 15000));
DataStore.Vehicules.Add(new Voiture("2-DEF-456", "Peugeot 308", 55, 23000));
DataStore.Vehicules.Add(new Moto("3-GHI-789", "Honda CBR", 60, 8000, 600));
DataStore.Vehicules.Add(new Velomoteur("4-JKL-012", "Yamaha Neo", 25, 3000, 50));
DataStore.Vehicules.Add(new Camion("5-MNO-345", "Mercedes Actros", 120, 50000, 3.5));
DataStore.Vehicules.Add(new MobilHome("6-PQR-678", "Hymer B678", 150, 12000, 6));
DataStore.Vehicules.Add(new Limousine("7-STU-901", "Lincoln Town Car", 200, 5000, 8));
DataStore.Vehicules.Add(new Autobus("8-VWX-234", "Mercedes Sprinter", 180, 30000, 20));
Console.WriteLine($"{DataStore.Vehicules.Count} véhicules ajoutés !");

// Étape 2 : Ajout des clients avec différents types de permis
Console.WriteLine("\n--- Ajout des clients ---");
DataStore.Clients.Add(new Client("Dupont", "Jean", "B"));   // Permis B -> peut louer une voiture
DataStore.Clients.Add(new Client("Martin", "Sophie", "A")); // Permis A -> peut louer une moto
DataStore.Clients.Add(new Client("Durant", "Paul", "C"));   // Permis C -> peut louer un camion
Console.WriteLine($"{DataStore.Clients.Count} clients ajoutés !");

// Étape 3 : Ajout des chauffeurs disponibles pour les véhicules qui l'exigent
Console.WriteLine("\n--- Ajout des chauffeurs ---");
DataStore.Chauffeurs.Add(new Chauffeur("Leblanc", "Marc"));
DataStore.Chauffeurs.Add(new Chauffeur("Leroy", "Julie"));
Console.WriteLine($"{DataStore.Chauffeurs.Count} chauffeurs ajoutés !");

// Étape 4 : Création d'une location simple
// Dupont (permis B) loue la Renault Clio pour 3 jours
Console.WriteLine("\n--- Création d'une location ---");
Client clientDupont = DataStore.Clients[0];
Vehicule renaultClio = DataStore.Vehicules[0];
Location location1 = new Location(clientDupont, renaultClio, 3);
renaultClio.EstDisponible = false;
DataStore.Location.Add(location1);
Console.WriteLine($"Location créée : {clientDupont.Nom} loue {renaultClio.Modele} pour 3 jours → {location1.MontantTotal}€");

// Étape 5 : Création d'une location avec chauffeur obligatoire
// Martin loue une Limousine qui nécessite un chauffeur
Console.WriteLine("\n--- Création d'une location avec chauffeur ---");
Client clientMartin = DataStore.Clients[1];
Vehicule limousine = DataStore.Vehicules[6];
Chauffeur chauffeur = DataStore.Chauffeurs[0];
chauffeur.EstDisponible = false;
Location location2 = new Location(clientMartin, limousine, 2, chauffeur);
limousine.EstDisponible = false;
DataStore.Location.Add(location2);
Console.WriteLine($"Location créée : {clientMartin.Nom} loue {limousine.Modele} avec chauffeur {chauffeur.Nom} pour 2 jours → {location2.MontantTotal}€");

// Étape 6 : Retour d'un véhicule endommagé
// La Renault Clio revient endommagée et est envoyée en réparation
Console.WriteLine("\n--- Retour de location avec dégâts ---");
location1.EstTerminee = true;
renaultClio.EstDisponible = false;
Reparation reparation = new Reparation(renaultClio, "Pare-choc endommagé", 3);
DataStore.Reparation.Add(reparation);
Console.WriteLine($"Véhicule {renaultClio.Modele} envoyé en réparation : {reparation.Description}");

// Étape 7 : Ajout d'un contrôle technique
// Le prochain contrôle est automatiquement planifié 2 ans après
Console.WriteLine("\n--- Ajout d'un contrôle technique ---");
ControleTechnique controle = new ControleTechnique(DataStore.Vehicules[1], "RAS", true);
DataStore.ControleTechnique.Add(controle);
Console.WriteLine($"Contrôle technique ajouté pour {DataStore.Vehicules[1].Modele} | Prochain : {controle.DateProchainControle.ToShortDateString()}");

// Étape 8 : Inscription d'un client à une formation
// Durant s'inscrit à une formation pour obtenir le permis D
Console.WriteLine("\n--- Inscription à une formation ---");
Client clientDurant = DataStore.Clients[2];
Formation formation = new Formation(clientDurant, "D", 30);
DataStore.Formation.Add(formation);
Console.WriteLine($"Formation permis D ajoutée pour {clientDurant.Nom} {clientDurant.Prenom}");

// Étape 9 : Affichage du résumé final du scénario
Console.WriteLine("\n=== RÉSUMÉ DU SCÉNARIO ===");
Console.WriteLine($"Véhicules : {DataStore.Vehicules.Count}");
Console.WriteLine($"Clients : {DataStore.Clients.Count}");
Console.WriteLine($"Chauffeurs : {DataStore.Chauffeurs.Count}");
Console.WriteLine($"Locations : {DataStore.Location.Count}");
Console.WriteLine($"Réparations : {DataStore.Reparation.Count}");
Console.WriteLine($"Contrôles techniques : {DataStore.ControleTechnique.Count}");
Console.WriteLine($"Formations : {DataStore.Formation.Count}");

// Pause avant de lancer le menu principal
Console.WriteLine("\n=== FIN DU SCÉNARIO - Appuyez sur Enter pour accéder au menu ===");
Console.ReadLine();

// Lancement du menu principal de l'application
MenuPrincipal menuPrincipal = new MenuPrincipal();
menuPrincipal.Afficher();