using System;
using System.Collections.Generic;
using System.Text;
using iQuest.GrandCircus.CircusModel;

namespace iQuest.GrandCircus.Animals
{
    internal class Tiger : AnimalBase
    {
        public Tiger(string name) : base(name)
        {
        }
        public override string MakeSound()
        {
            return "roar";
        }
        protected override string GetSpeciesName()
        {
            return "Tiger";
        }
    }
}
