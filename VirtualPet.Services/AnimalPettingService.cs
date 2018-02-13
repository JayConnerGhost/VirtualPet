using VirtualPet.Models;
using VirtualPet.Repositories;

namespace VirtualPet.Services
{
    public class AnimalPettingService : IAnimalPettingService
    {
        private readonly AnimalFindService _animalFindService;
        private InMemoryAnimalRepository _inMemoryAnimalRepository;

        public AnimalPettingService(AnimalFindService animalFindService, InMemoryAnimalRepository inMemoryAnimalRepository)
        {
            this._animalFindService = animalFindService;
            this._inMemoryAnimalRepository = inMemoryAnimalRepository;
        }

        public void Pet(AnimalIdentifier animalIdentifier)
        {
            var animal = _animalFindService.GetByIdentifier(animalIdentifier);
            animal.Pet();
        }
    }
}