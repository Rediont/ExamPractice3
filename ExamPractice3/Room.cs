using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPractice3
{
    public abstract class Room
    {
        public int Id { get; private set; }
        public string Name { get; init; }
        public int Cost { get; private set; }
        public string? Occupier { get; set; }
        public RoomStatus Status { get; set; }

        private Dictionary<string, bool> additionalFeatures = new Dictionary<string, bool>()
        {
            {"Free Coffe", false},
            {"Pool", false },
            {"Breakfast", false}
        };

        public Room(int id, string name, int cost)
        {
            Id = id;
            Name = name;
            Cost = cost;
        }

        public bool IsFeatureAvailable(string featureName)
        {
            if (additionalFeatures.ContainsKey(featureName))
            {
                return additionalFeatures[featureName];
            }
            return false;
        }
    }
}
