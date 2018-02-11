using System;
using System.Collections.Generic;
using VirtualPet.Models;

namespace VirtualPet.Repositories
{
    public class InMemoryPetRepository : IPetRepository
    {
        private readonly List<Pet> _listOfPets;

        public InMemoryPetRepository(IPets listOfPets)
        {
            _listOfPets = (List<Pet>) listOfPets;
        }

        public IEnumerable<Pet> GetByUserId(string userName)
        {
           return _listOfPets.FindAll(x => x.Owner == userName);
        }

        Pet IPetRepository.GetByUserIdandPetName(string userName, string petName)
        {
            return _listOfPets.Find(x => (x.Name == petName) && (x.Owner == userName));
        }
    }
}