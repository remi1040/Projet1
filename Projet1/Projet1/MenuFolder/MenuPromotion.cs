using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet1.Models;

namespace Projet1.MenuFolder
{
    internal class MenuPromotion
    {
        public MenuPromotion() { }

        public static void AfficherMenuPromotion()
        {
            Console.WriteLine(" 1 - Lister les promotions existantes");
            Console.WriteLine(" 2 - Lister les élèves dans une promotion existante ");
            Console.WriteLine(" 3 - Afficher les moyennes pour les cours dans une promotion");
            Console.WriteLine(" 4 - Revenir au menu principal");
        }

        public static void ListePromo(List<Eleves> readEleves)
        {
            List<string> promo = new List<string>();
            foreach (Eleves eleve in readEleves)
            {
                if (promo.Contains(eleve.Promo.NomPromo))
                {
                    continue;
                }
                else
                {
                    promo.Add(eleve.Promo.NomPromo);
                }
            }
            foreach (string p in promo)
            {
                Console.WriteLine($"Promotion : {p}");
            }
        }

        public static void ListeElevePromo(List<Eleves> readEleves)
        {
            Console.WriteLine("Voici la liste des promotions : ");
            Console.WriteLine();
            ListePromo(readEleves);
            Console.WriteLine();
            Console.WriteLine("De quelle promotion voulez-vous la liste des élèves ? ");
            Console.WriteLine();
            string p = Console.ReadLine();
            Promotion promo = new Promotion(p);
            bool flag = false;
            foreach (Eleves eleve in readEleves)
            {
                if (eleve.Promo.NomPromo == promo.NomPromo)
                {
                    Console.WriteLine($"L'élève {eleve.Nom} {eleve.Prenom} est dans la promotion {promo.NomPromo}");
                    flag = true;
                }
            }
            if (!flag)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cette promotion n'existe pas ! ");
                Console.ForegroundColor = ConsoleColor.White;
                ListeElevePromo(readEleves);
            }
        }

        public static void MoyenneParPromo(List<Eleves> readEleves, List<Cours> readCours)
        {
            Console.WriteLine("Voici la liste des promotions : ");
            Console.WriteLine();
            ListePromo(readEleves);
            Console.WriteLine();
            Console.WriteLine("De quelle promotion voulez-vous la moyenne par cours ? ");
            Console.WriteLine();
            string p = Console.ReadLine();
            Promotion promo = new Promotion(p);



            foreach (Cours cours in readCours)
            {
                float moyenne = 0;
                int nombreNotes = 0;
                foreach (Eleves eleve in readEleves)
                {
                    if (eleve.CoursNotesAppreciations.ContainsKey(cours.NomCour))
                    {
                        foreach (NotesAppreciations note in eleve.CoursNotesAppreciations[cours.NomCour])
                        {
                            moyenne += note.Notes;
                            nombreNotes += 1;
                        }
                    }
                }
                Console.WriteLine($"Pour la matière {cours.NomCour} la moyenne est de {Eleves.ArrondiMoyenne(moyenne / nombreNotes)}");
            }
        }



    }
}
