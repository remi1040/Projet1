using Projet1.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Projet1.MenuFolder
{
    internal class MenuEleves
    {

        /* Fonction qui affiche le menu Eleves de l'application */
        public static void AfficherMenuEleves()
        {
            Console.WriteLine(" 1 - Lister les élèves");
            Console.WriteLine(" 2 - Créer un nouvel élève");
            Console.WriteLine(" 3 - Consulter un élève existant");
            Console.WriteLine(" 4 - Ajouter une note et une appréciation pour un cours sur un élève existant");
            Console.WriteLine(" 5 - Revenir au menu principal");
        }

        public static void ListeEleves(List<Eleves> readEleve)
        {
            if (readEleve != null)
            {
                foreach (Eleves eleve in readEleve)
                {
                    Console.WriteLine(eleve.NomPrenomEleve());
                }
            }
            Log.Information($"Consultation de la liste des élèves");
        }

        public static List<Eleves> NouvelEleves(List<Eleves> readEleve)
        {
            List<string> informations = EntreeUtilisateur.InfoCreerEleve();
            string nom = informations[0];
            string prenom = informations[1];
            string dateNaissance = informations[2];
            string promo = informations[3];

            if (readEleve != null)
            {
                if (!Verification.EleveExisteDeja(readEleve, nom, prenom))
                {
                    Eleves e = new Eleves(nom, prenom, dateNaissance, new Promotion(promo));
                    readEleve.Add(e);
                    Log.Information($"Création d'un nouvel élève : nom -> {nom} prénom -> {prenom} date de naissance -> {dateNaissance}");
                }
            }
            return readEleve;
        }

        public static void DetailsEleve(List<Eleves> readEleve)
        {
            Console.WriteLine("Voici la liste des élèves, quel élève souhaitez vous consulter ? ");
            foreach (Eleves eleve in readEleve)
            {
                Console.WriteLine(eleve.NomPrenomEleve());
            }
            Console.WriteLine("Ecrire le nom de l'élève : ");
            string nom = Console.ReadLine();
            Console.WriteLine("Ecrire le prénom de l'élève : ");
            string prenom = Console.ReadLine();

            bool flag = false;
            foreach (Eleves eleve in readEleve)
            {
                if (eleve.Nom == nom && eleve.Prenom == prenom)
                {
                    eleve.DetailEleve();
                    flag = true;
                    Log.Information($"Consultation des details de l'élève {nom} {prenom}");
                }
            }
            if (!flag)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Aucun éleve du nom de {nom} {prenom} n'est connu");
                Console.ForegroundColor = ConsoleColor.White;
                DetailsEleve(readEleve);
            }
        }
        public static List<Eleves> AjoutNoteAppreciation(List<Eleves> readEleve, List<Cours> readCours)
        {
            List<string> informations = EntreeUtilisateur.InfoEleveMatiereNoteAppreciation(readEleve, readCours);
            string nom = informations[0];
            string prenom = informations[1];
            string matiere = informations[2];

            bool flag = false;
            foreach (Eleves eleve in readEleve)
            {
                

                if (eleve.Nom == nom && eleve.Prenom == prenom)
                {
                    for (int i = 0; i < readCours.Count; i++)
                    {
                        if (readCours[i].NomCour == matiere)
                        {
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ce cours n'existe pas");
                        Console.ForegroundColor = ConsoleColor.White;

                        AjoutNoteAppreciation(readEleve, readCours);
                    }

                    float note = EntreeUtilisateur.InfoCreerNote();
                    string appreciation = EntreeUtilisateur.InfoCreerAppreciation();

                    if (note < 10)
                    {
                        Console.WriteLine($"Etes-vous sur de vouloir mettre une mauvaise note : {note} avec l'appréciation suivante : {appreciation} à l'élève {nom} {prenom} dans la matiere {matiere}");
                    }
                    else
                    {
                        Console.WriteLine($"Etes-vous sur de vouloir mettre une bonne note : {note} avec l'appréciation suivante : {appreciation} à l'élève {nom} {prenom} dans la matiere {matiere}");
                    }
                    string s1 = EntreeUtilisateur.Confirmation();

                    if (s1 == "1")
                    {
                        eleve.AjouterNotesEtAppreciation(note, appreciation, matiere);
                        flag = true;
                        Log.Information($"Ajout de la note {note} et de l'appréciation : {appreciation}");
                    }
                }
            }
            if (!flag)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Aucun élève ne correspond à ce nom ");
                Console.ForegroundColor = ConsoleColor.White;
                AjoutNoteAppreciation(readEleve, readCours);
            }
            return readEleve;
        }



    }
}
