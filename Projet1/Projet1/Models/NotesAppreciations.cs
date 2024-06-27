using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet1.Models
{
    internal class NotesAppreciations
    {
        public float Notes { get; set; }
        public string Appreciation { get; set; }
        public NotesAppreciations(float notes, string appreciation)
        {
            Notes = notes;
            Appreciation = appreciation;
        }

    }
}
