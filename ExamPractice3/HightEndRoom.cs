﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPractice3
{
    public class GoodRoom : Room
    {
        Dictionary<string, bool> additionalFeatures = new Dictionary<string, bool>()
        {
            {"Free Coffe" ,false},{"Pool" ,false },{"Breakfast" , true}
        };

        public GoodRoom(int id, string name, int cost) : base(id, name, cost) { }
    }

    public class HighEndRoom : Room
    {
        Dictionary<string, bool> additionalFeatures = new Dictionary<string, bool>()
        {
            {"Free Coffe" ,true},{"Pool" ,true }, {"Breakfast" , true}
        };

        public HighEndRoom(int id, string name, int cost) : base(id, name, cost) { }
    }

}
