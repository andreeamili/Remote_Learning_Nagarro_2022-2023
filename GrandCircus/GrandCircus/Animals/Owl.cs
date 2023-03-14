using System;
using System.Collections.Generic;
using System.Text;
using iQuest.GrandCircus.CircusModel;

namespace iQuest.GrandCircus.Animals
{
    internal class Owl : AnimalBase
    {
        public Owl(string name) : base(name)
        {
        }
        public override string MakeSound()
        {
            return "Buhuhu";
        }
        protected override string GetSpeciesName()
        {
            return "Owl";
        }
    }
}
