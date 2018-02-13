using VirtualPet.Models;
using VirtualPet.Repositories;

namespace VirtualPet.Services
{
    public class AnimalPettingService : IAnimalPettingService
    {
        private readonly IAnimalFindService _animalFindService;
        private IAnimalRepository _inMemoryAnimalRepository;

        public AnimalPettingService(IAnimalFindService animalFindService, IAnimalRepository inMemoryAnimalRepository)
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