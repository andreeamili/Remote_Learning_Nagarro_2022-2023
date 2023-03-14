using iQuest.GrandCircus.Animals;
using iQuest.GrandCircus.Interfaces;
using iQuest.GrandCircus.Presentation;
using System.Collections.Generic;

namespace iQuest.GrandCircus.CircusModel
{
    internal class Circus 
    {
        private List<IAnimal> animalList = new List<IAnimal>();
        private Arena arena=new Arena();
        public Circus(Arena arena)
        {
            animalList.Add(new Owl("Foxy"));

            animalList.Add(new Elephant("Dumbo"));
            
            animalList.Add(new Duck("Duffy"));
            
            animalList.Add(new Tiger("Rainy"));
            
            animalList.Add(new Horse("Rico"));
            
            animalList.Add(new Duck("Duby"));
            
            animalList.Add(new Snake("Lizy"));
            
            animalList.Add(new Raven("Bran"));
        }
        public void Perform()
        {
            arena.PresentCircus("Alandala");

            foreach(IAnimal Animals in animalList)
            {
                arena.AnnounceAnimal(Animals.Name, Animals.SpeciesName);
                arena.DisplayAnimalPerformance(Animals.MakeSound());

            }
        }
    }
}