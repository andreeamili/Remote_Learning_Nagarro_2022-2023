using System;
using System.Collections.Generic;
using System.Text;
using iQuest.GrandCircus.CircusModel;

namespace iQuest.GrandCircus.Animals
{
    internal class Horse : AnimalBase 
    {
        public Horse(string name) : base(name)
        {
        }
        public override string MakeSound()
        {
            return "neigh";
        }
        protected override string GetSpeciesName()
        {
            return "Horse";
        }
    }
}
