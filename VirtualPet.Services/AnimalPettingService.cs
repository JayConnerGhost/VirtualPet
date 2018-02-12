using VirtualPet.Models;
using VirtualPet.Repositories;

namespace VirtualPet.Services
{
    public class AnimalPettingService : IAnimalPettingService
    {
        private AnimalFindService animalFindService;
        private InMemoryAnimalRepository inMemoryAnimalRepository;

        public AnimalPettingService(AnimalFindService animalFindService, InMemoryAnimalRepository inMemoryAnimalRepository)
        {
            this.animalFindService = animalFindService;
            this.inMemoryAnimalRepository = inMemoryAnimalRepository;
        }

        public void Pet(AnimalIdentifier animalIdentifier)
        {
            var animal = animalFindService.GetByIdentifier(animalIdentifier);
            animal.Pet();
        }
    }
}