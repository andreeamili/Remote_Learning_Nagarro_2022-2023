using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using iQuest.GrandCircus.CircusModel;

namespace iQuest.GrandCircus.Animals
{
    internal class Raven : AnimalBase
    {
        public Raven(string name) :base(name)
        {
        }
        public override string MakeSound()
        {
            return "Cra Cra";
        }
        protected override string GetSpeciesName()
        {
            return "Raven";
        }
    }
}
