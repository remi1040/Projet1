using Projet1.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet1.MenuFolder
{
    internal class MenuCours
    {

        /* Fonction qui affiche le menu Cours de l'application */
        public static void AfficherMenuCours()
        {
            Console.WriteLine(" 1 - Lister les cours existants");
            Console.WriteLine(" 2 - Ajouter un nouveau cours au programme");
            Console.WriteLine(" 3 - Supprimer un cours par son identifiant");
            Console.WriteLine(" 4 - Afficher les moyennes par promo");
            Console.WriteLine(" 5 - Revenir au menu principal");
        }

        public static void AfficherCours(List<Cours> readCours)
        {
            foreach (Cours cours in readCours)
            {
                Console.WriteLine($"{cours.NomCour} avec comme id : {cours.IdCour}");
            }
            Log.Information($"Consultation de la liste des cours");
        }

        public static List<Cours> AjouterCours(List<Cours> readCours)
        {
            string nom = EntreeUtilisateur.InfoCreerCours(readCours);

            if (!Verification.CoursExisteDeja(readCours, nom))
            {
                Cours e = new Cours(nom);
                readCours.Add(e);
                Log.Information($"Ajout du cours {nom}");
                
            }
            return readCours;
        }

        public static (List<Cours>, List<Eleves>) SupprimerCours(List<Cours> readCours, List<Eleves> readEleve)
        {
            int IdCoursASupprimer = EntreeUtilisateur.InfoSupprimerCours(readCours);
            if (IdCoursASupprimer == -1)
            {
                return (readCours,readEleve);
            }
            bool flag = false;
            for (int i = 0; i < readCours.Count; i++)
            {
                if (readCours[i].IdCour == IdCoursASupprimer)
                {
                    Console.WriteLine("Cours supprimé");
                    Log.Information($"Suppression du cours {IdCoursASupprimer}");
                    flag = true;
                    string cours = readCours[i].NomCour;
                    readCours.RemoveAt(i);

                    foreach (Eleves e in readEleve)
                    {
                        // Suppresion de la matiere dans le dico de l'eleve
                        if (e.CoursNotesAppreciations != null)
                        {
                            foreach (KeyValuePair<string, List<NotesAppreciations>> e2 in e.CoursNotesAppreciations)
                            {
                                if (e2.Key.Equals(IdCoursASupprimer))
                                {
                                    e.CoursNotesAppreciations.Remove(cours);
                                    Console.WriteLine(e2.Key);
                                }
                            }
                        }
                    }
                }
            }
            if (!flag)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erreur de saisi pour supprimer le cours");
                Console.ForegroundColor = ConsoleColor.White;

                SupprimerCours(readCours, readEleve);

            }
            return (readCours, readEleve);
        }

        public static void AfficherMoyenneParPromo(List<Eleves> readEleves)
        {
            //faire la liste des moyennes par promo
        }
    }
}
