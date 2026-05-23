using examen_csharpV2.UI;
using examen_csharpV2.Models;
using examen_csharpV2.Service;

// Données de test - Véhicules
DataStore.Vehicules.Add(new Voiture("1-ABC-123", "Renault Clio", 45, 15000));
DataStore.Vehicules.Add(new Voiture("2-DEF-456", "Peugeot 308", 55, 23000));
DataStore.Vehicules.Add(new Moto("3-GHI-789", "Honda CBR", 60, 8000, 600));
DataStore.Vehicules.Add(new Velomoteur("4-JKL-012", "Yamaha Neo", 25, 3000, 50));
DataStore.Vehicules.Add(new Camion("5-MNO-345", "Mercedes Actros", 120, 50000, 3.5));
DataStore.Vehicules.Add(new MobilHome("6-PQR-678", "Hymer B678", 150, 12000, 6));
DataStore.Vehicules.Add(new Limousine("7-STU-901", "Lincoln Town Car", 200, 5000, 8));
DataStore.Vehicules.Add(new Autobus("8-VWX-234", "Mercedes Sprinter", 180, 30000, 20));

// Données de test - Clients
DataStore.Clients.Add(new Client("Dupont", "Jean", "B"));
DataStore.Clients.Add(new Client("Martin", "Sophie", "A"));
DataStore.Clients.Add(new Client("Durant", "Paul", "C"));

// Données de test - Chauffeurs
DataStore.Chauffeurs.Add(new Chauffeur("Leblanc", "Marc"));
DataStore.Chauffeurs.Add(new Chauffeur("Leroy", "Julie"));





MenuPrincipal menuPrincipal = new MenuPrincipal();
menuPrincipal.Afficher();