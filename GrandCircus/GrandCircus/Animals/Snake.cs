using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using iQuest.GrandCircus.CircusModel;

namespace iQuest.GrandCircus.Animals
{
    internal class Snake : AnimalBase
    {
        public Snake(string name) : base(name)
        {
            
           // this.SpeciesName = "Snake";
        }
        
        public override string MakeSound()
        {
            return "Shhhh";
        }

        protected override string GetSpeciesName()
        {
            return "Snake";
        }
    }
}
