using System.Collections.Generic;
using VirtualPet.Models;
using VirtualPet.Repositories;

namespace VirtualPet.Services
{
    public class AnimalFindService:IAnimalsFindService
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalFindService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public IEnumerable<IAnimal> GetByUserId(string userName)
        {
           return _animalRepository.GetByUserId(userName);
        }

        public IAnimal GetByIdentifier(AnimalIdentifier animal)
        {
            return _animalRepository.GetByUserIdandAnimalName(animal.UserId, animal.AnimalName);
        }
    }
}