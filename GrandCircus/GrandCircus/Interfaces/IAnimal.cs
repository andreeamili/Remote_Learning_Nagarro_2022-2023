using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace iQuest.GrandCircus.Interfaces
{
    internal interface IAnimal
    {
        string Name { get; }
        string SpeciesName { get; }
        string MakeSound();
    }
}
