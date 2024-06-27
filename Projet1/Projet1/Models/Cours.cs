using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet1.Models
{
    internal class Cours
    {
        private static int _nextId = 1;
        public string NomCour { get; set; }
        public int IdCour { get; set; }
        public Cours(string nomCour)
        {
            NomCour = nomCour;
            IdCour = _nextId; 
            _nextId++;
        }
    }
}
