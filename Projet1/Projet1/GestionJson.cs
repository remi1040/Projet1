using Newtonsoft.Json;
using Projet1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet1
{
    internal class GestionJson
    {
        public string PathJson { get; set; }
        public GestionJson(string pathJson) 
        {
            this.PathJson = pathJson;
        }

        public List<Eleves> LoadJsonEleves()
        {
            return JsonConvert.DeserializeObject<List<Eleves>>(File.ReadAllText(this.PathJson)) ?? new List<Eleves>();
        }

        public List<Cours> LoadJsonCours()
        {
            return JsonConvert.DeserializeObject<List<Cours>>(File.ReadAllText(this.PathJson)) ?? new List<Cours>();
        }

        public void SaveJson(List<Eleves> eleves)
        {
            // Ecriture du nouveau fichier Json Eleves
            File.WriteAllText(this.PathJson, JsonConvert.SerializeObject(eleves));

        }

        public void SaveJson(List<Cours> cours)
        {
            // Ecriture du nouveau fichier Json Cours
            File.WriteAllText(this.PathJson, JsonConvert.SerializeObject(cours));

        }
        

            
    }
}
