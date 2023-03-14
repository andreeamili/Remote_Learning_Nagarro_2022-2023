using iQuest.GrandCircus.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.GrandCircus.CircusModel
{

    public abstract class AnimalBase : IAnimal
    {
        public string Name { get; protected set; }
        public string SpeciesName { get; protected set; }
        protected AnimalBase(string name)
        {
            if (name != null)
            {
                Name = name;
            }
            else
            {
                Name = "Someone";
            }
            SpeciesName = GetSpeciesName();
        }
        protected abstract string GetSpeciesName();
        public abstract string MakeSound();
    }
}
