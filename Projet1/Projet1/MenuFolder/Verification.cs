using Projet1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet1.MenuFolder
{
    internal class Verification
    {
        public static bool EleveExisteDeja(List<Eleves> readEleve, string nom, string prenom)
        {
            foreach (Eleves eleve in readEleve)
            {
                if (eleve.Nom == nom && eleve.Prenom == prenom)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("L'élève existe deja ! ");
                    Console.ForegroundColor = ConsoleColor.White;
                    return true;
                }
            }
            return false;
        }

        public static bool CoursExisteDeja(List<Cours> readCours, string nom)
        {
            foreach (Cours c in readCours)
            {
                if (c.NomCour == nom)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Le cours existe deja ! ");
                    Console.ForegroundColor = ConsoleColor.White;

                    MenuCours.AjouterCours(readCours);
                    return true;
                }
            }
            return false;
        }
    }
}
