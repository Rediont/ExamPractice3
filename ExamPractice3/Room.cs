using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPractice3
{
    public class Room
    {
        private string id;
        public readonly string Name;
        private int cost;
        private Dictionary<string, bool> additionalFeatures = new Dictionary<string, bool>()
        {
            {"Free Coffe" ,false},{"Pool" ,false },{"Breakfast" , false}
        };
        private string occupier;
        public string Occupier { get {return occupier;} set { occupier = value; } }
        public int Cost { get { return cost; } }
        public string Id { get { return id; } }

        public Room(string id, string name, int cost)
        {
            this.id = id;
            Name = name;
            this.cost = cost;
        }

        public bool AviableFeatures(string featureName)
        {
            if (additionalFeatures.ContainsKey(featureName)) 
            {
                return additionalFeatures[featureName]; 
            } 
            else 
            {
                throw new Exception("no such feature");
            }
        }

    }
}
