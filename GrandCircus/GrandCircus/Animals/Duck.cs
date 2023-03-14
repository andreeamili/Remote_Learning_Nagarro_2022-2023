using System;
using System.Collections.Generic;
using System.Text;
using iQuest.GrandCircus.CircusModel;

namespace iQuest.GrandCircus.Animals
{
    internal class Duck : AnimalBase
    {
        public Duck(string name) : base(name)
        {
        }
        public override string MakeSound()
        {
            return "quack";
        }
        protected override string GetSpeciesName()
        {
            return "Duck";
        }
    }
}
