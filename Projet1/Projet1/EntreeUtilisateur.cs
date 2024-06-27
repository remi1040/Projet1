using Projet1.MenuFolder;
using Projet1.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Projet1
{
    internal class EntreeUtilisateur
    {
        public static List<string> InfoCreerEleve()
        {
            Console.WriteLine("Quel est le nom du nouvel élève ? ");
            string nom = Console.ReadLine();

            Console.WriteLine("Quel est le prénom du nouvel élève ? ");
            string prenom = Console.ReadLine();

            Console.WriteLine("Quel est la date de naissance du nouvel élève ? ");
            string dateNaissance = Console.ReadLine();

            Console.WriteLine("Dans quelle promotion est le nouvel élève ? ");
            string promotion = Console.ReadLine();

            Console.WriteLine($"Vous allez créer l'élève suivant : nom -> {nom} prénom -> {prenom} date de naissance -> {dateNaissance}");

            string s1 = Confirmation();

            if (s1 == "1")
            {
                return [nom, prenom, dateNaissance, promotion];
            }
            else
            {
                Console.WriteLine("Vous avez annuler l'ajout de l'élève");
                MenuEleves.AfficherMenuEleves();
                return [];
            }
        }

        public static string InfoCreerCours(List<Cours> readCours)
        {
            Console.WriteLine("Voici les cours déja présent");
            MenuCours.AfficherCours(readCours);
            Console.WriteLine();
            Console.WriteLine("Quel est le nom du nouveau cours ? ");
            string nom = Console.ReadLine();

            Console.WriteLine($"Vous allez créer le cours suivant : nom du cours -> {nom}");


            string s1 = Confirmation();

            if (s1 == "1")
            {
                return nom;
            }

            else
            {
                Console.WriteLine("Vous avez annuler l'ajout du cours");
                return "";
            }
        }

        public static int InfoSupprimerCours(List<Cours> readCours)
        {
            MenuCours.AfficherCours(readCours);
            Console.WriteLine();
            Console.WriteLine("Quel cours voulez vous supprimer ? Selectionner un Id ");
            int.TryParse(Console.ReadLine(), out int sup);
            Console.WriteLine($"Etes vous sur de vouloir supprimer le cours qui à pour Id {sup} ?");
            string s1 = Confirmation();
            if (s1 == "1")
            {
                return sup;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vous avez annuler la suppression du cour");
                Console.ForegroundColor = ConsoleColor.White;
                return -1;
            }
            
        }

        public static List<string> InfoEleveMatiereNoteAppreciation(List<Eleves> readEleve, List<Cours> readCours)
        {
            Console.WriteLine("Voici la liste des élèves disponnible : ");
            MenuEleves.ListeEleves(readEleve);
            Console.WriteLine();
            Console.WriteLine("Ecrire le nom de l'élève : ");
            string nom = Console.ReadLine();
            Console.WriteLine("Ecrire le prénom de l'élève : ");
            string prenom = Console.ReadLine();
            Console.WriteLine("Dans quelle matière il faut ajouter une note ? ");
            MenuCours.AfficherCours(readCours);
            //liste des matières 
            string matiere = Console.ReadLine();

            return [nom,prenom,matiere];
        }

        public static float InfoCreerNote()
        {
            Console.WriteLine("Ajouter une note");
            float.TryParse(Console.ReadLine(), out float note);
            return note;
        }

        public static string InfoCreerAppreciation()
        {
            Console.WriteLine("Ajouter une appréciations si necessaire : ");
            string appreciation = Console.ReadLine();
            return appreciation;
        }

        public static string Confirmation()
        {
            Console.WriteLine(" 1 - Confirmer ");
            Console.WriteLine(" 2 - Annuler ");
            return Console.ReadLine();
        }


    }
}
