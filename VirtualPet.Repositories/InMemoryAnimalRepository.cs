using System;
using System.Collections.Generic;
using VirtualPet.Models;

namespace VirtualPet.Repositories
{
    public class InMemoryAnimalRepository : IAnimalRepository
    {
        private readonly List<IAnimal> _listOfPets;

        public InMemoryAnimalRepository(IAnimals listOfAnimals)
        {
            _listOfPets = (List<IAnimal>) listOfAnimals;
        }

        public IEnumerable<IAnimal> GetByUserId(string userName)
        {
           return _listOfPets.FindAll(x => x.Owner == userName);
        }

        IAnimal IAnimalRepository.GetByUserIdandAnimalName(string userName, string petName)
        {
            return _listOfPets.Find(x => (x.Name == petName) && (x.Owner == userName));
        }
    }
}