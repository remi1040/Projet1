using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Projet1.Models
{
    internal class Eleves
    {
        public static int Id = 0;
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string DateNaissance { get; }

        public Dictionary<string, List<NotesAppreciations>> CoursNotesAppreciations { get; set; }

        [JsonIgnore]
        public float Moyenne { get; set; }

        public Promotion Promo { get; set; }


        public Eleves(string nom, string prenom, string dateNaissance, Promotion promo)
        {
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            CoursNotesAppreciations = new Dictionary<string, List<NotesAppreciations>>();
            Promo = promo;
            Id++;
        }

        public string NomPrenomEleve()
        {
            return $" - {Prenom} {Nom} ";
        }

        /*public string NomPromo()
        {
            return Promo.NomPromo;
        }*/

        public void DetailEleve()
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Informations sur l'élève : ");
            Console.WriteLine($"Nom               : {Nom}");
            Console.WriteLine($"Prénom            : {Prenom}");
            Console.WriteLine($"Date de naissance : {DateNaissance}");
            //Console.WriteLine("{0,10} {1,10} {2,30}",this.Nom, this.Prenom, this.DateNaissance);
            Console.WriteLine("Résultat scolaire");
            Console.WriteLine();

            if (CoursNotesAppreciations != null)
            {
                foreach (KeyValuePair<string, List<NotesAppreciations>> noteAppreciation in CoursNotesAppreciations)
                {
                    Console.WriteLine($"Cours : {noteAppreciation.Key}");
                    foreach (NotesAppreciations n in noteAppreciation.Value)
                    {
                        Console.WriteLine($"Votre note est de : {n.Notes} avec l'appréciation suivante : {n.Appreciation}");
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine($" Moyenne : {MoyenneEleve()}/20");
            Console.WriteLine("----------------------------------------------------------------------");
        }

        public double MoyenneEleve()
        {
            float moyenne = 0;
            int nombreNote = 0;
            if (CoursNotesAppreciations != null)
            {
                foreach (KeyValuePair<string, List<NotesAppreciations>> noteAppreciation in CoursNotesAppreciations)
                {

                    foreach (NotesAppreciations n in noteAppreciation.Value)
                    {
                        moyenne += n.Notes;
                        nombreNote += 1;

                    }
                }
            }
            return ArrondiMoyenne(moyenne / nombreNote);
        }

        public void AjouterNotesEtAppreciation(float note, string appreciation, string matiere)
        {
            NotesAppreciations na1 = new NotesAppreciations(note, appreciation);
            if (CoursNotesAppreciations.ContainsKey(matiere))
            {
                CoursNotesAppreciations[matiere].Add(na1);
            }
            else
            {
                CoursNotesAppreciations.Add(matiere, [na1]);
            }
            Console.WriteLine("ajouté");

        }

        public static double ArrondiMoyenne(float moyenne)
        {
            // Extraire les parties entière et décimale
            double integerPart = Math.Floor(moyenne);
            double fractionalPart = moyenne - integerPart;

            // Multiplier la partie décimale par 10 pour obtenir la première décimale
            double firstDecimal = Math.Floor(fractionalPart * 10);

            // Multiplier la partie décimale par 100 pour obtenir la deuxième décimale
            double secondDecimal = Math.Floor(fractionalPart * 100 % 10);

            if (secondDecimal < 3)
            {
                return integerPart + firstDecimal / 10;
            }
            else if (secondDecimal >= 3 && secondDecimal < 6)
            {
                return integerPart + firstDecimal / 10 + 0.5;
            }
            else
            {
                return integerPart + Math.Ceiling(firstDecimal / 10);
            }
        }
    }
}
