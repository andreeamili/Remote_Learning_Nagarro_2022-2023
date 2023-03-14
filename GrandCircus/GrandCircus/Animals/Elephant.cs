using System;
using System.Collections.Generic;
using System.Text;
using iQuest.GrandCircus.CircusModel;

namespace iQuest.GrandCircus.Animals
{
    internal class Elephant : AnimalBase
    {
        public Elephant(string name) : base(name)
        {
        }
        public override string MakeSound()
        {
            return "Pffffteee";
        }
        protected override string GetSpeciesName()
        {
            return "Elephant";
        }
    }
}
