using Serilog.Events;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Projet1.Models;
using Projet1.MenuFolder;

namespace Projet1
{
    internal class RunApp
    {
        public string PathListeEleves { get;}
        public string PathListeCours { get;}

        public string PathLog { get;}

        public RunApp()
        {
            // path fichier de sauvegarde Eleves
            PathListeEleves = "../../../eleves.json";
            // path fichier de sauvegarde Cours
            PathListeCours = "../../../cours.json";
            // path fichier de log
            PathLog = "../../../log.txt";

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File(PathLog, LogEventLevel.Information)
            .WriteTo.Console()
            .CreateLogger();

            LancerApplication();
        }
        public RunApp(IDataApp dataApp)
        {

        }
        public void LancerApplication()
        {
            
            
            GestionJson gestionJsonEleve = new GestionJson(PathListeEleves);
            GestionJson gestionJsonCours = new GestionJson(PathListeCours);
            
            var readEleve = gestionJsonEleve.LoadJsonEleves();
            var readCours = gestionJsonCours.LoadJsonCours();

            while (true)
            {
                // Affichage du menu
                Menu.AfficherMenu();
                string s1 = Console.ReadLine();
                if (s1 == "1")
                {
                    // Affichage Menu Eleves
                    MenuEleves.AfficherMenuEleves();
                    s1 = Console.ReadLine();

                    // Affichage de tous les éleves present dans les fichiers
                    if (s1 == "1")
                    {
                        MenuEleves.ListeEleves(readEleve);
                    }
                    // Création d'un nouvel élèves
                    if (s1 == "2")
                    {
                        readEleve = MenuEleves.NouvelEleves(readEleve);
                    }

                    // Consultation du details des élèves 
                    if (s1 == "3")
                    {
                        MenuEleves.DetailsEleve(readEleve);
                        continue;

                    }
                    // Ajouter une note et une appréciation d'un éleve
                    if (s1 == "4")
                    {
                        readEleve = MenuEleves.AjoutNoteAppreciation(readEleve, readCours);
                    }
                    // retour au menu principal
                    if (s1 == "5")
                    {
                        Log.Information($"Retour au menu principal");
                        continue;
                    }
                    continue;
                }
                if (s1 == "2")
                {
                    MenuCours.AfficherMenuCours();
                    s1 = Console.ReadLine();

                    if (s1 == "1")
                    {
                        MenuCours.AfficherCours(readCours);
                    }
                    if (s1 == "2")
                    {
                        readCours = MenuCours.AjouterCours(readCours);
                    }
                    if (s1 == "3")
                    {
                        (readCours, readEleve) = MenuCours.SupprimerCours(readCours, readEleve);
                    }
                    if (s1 == "4")
                    {
                        Log.Information($"Affichage par cours des moyennes par promo ");

                    }
                    if (s1 == "5")
                    {
                        Log.Information($"Retour au menu principal");
                        continue;
                    }
                    continue;
                }
                if (s1 == "3")
                {
                    MenuPromotion.AfficherMenuPromotion();
                    s1 = Console.ReadLine();

                    if (s1 == "1")
                    {
                        MenuPromotion.ListePromo(readEleve);
                        Log.Information($"Affichage des différentes promotions ");
                    }
                    if (s1 == "2")
                    {
                        MenuPromotion.ListeElevePromo(readEleve);
                        Log.Information($"Affichage des différentes élèves pour une promotions ");
                    }
                    if (s1 == "3")
                    {
                        MenuPromotion.MoyenneParPromo(readEleve, readCours);
                    }
                    if (s1 == "4")
                    {
                        Log.Information($"Retour au menu principal");
                        continue;
                    }
                    continue;
                }
                if (s1 == "4")
                {
                    Log.Information($"Application quitté");
                    break;
                }
            }

            gestionJsonEleve.SaveJson(readEleve);
            gestionJsonCours.SaveJson(readCours);
        }

    }
}
