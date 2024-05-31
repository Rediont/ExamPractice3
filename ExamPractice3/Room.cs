using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPractice3
{
    public class Room
    {
        public int _id { get; private set; }
        public readonly string _name;
        public int _cost { get; private set; }
        public string Occupier { get; set; }
        public string Status { get; set; }
        private Dictionary<string, bool> additionalFeatures = new Dictionary<string, bool>()
        {
            {"Free Coffe" ,false},{"Pool" ,false },{"Breakfast" , false}
        };

        public Room(int id, string name, int cost)
        {
            _id = id;
            _name = name;
            _cost = cost;
        }

        public bool IsFeatureAvailable(string featureName)
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
