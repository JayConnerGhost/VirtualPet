using System;
using VirtualPet.Models;

namespace VirtualPet.Services
{
    public class AnimalFeedingService : IAnimalFeedingService
    {
        private readonly AnimalFindService _animalFindService;

        public AnimalFeedingService(AnimalFindService animalFindService)
        {
            _animalFindService = animalFindService;
        }

        public void Feed(AnimalIdentifier identifier)
        {
            _animalFindService.GetByIdentifier(identifier).Feed();
        }
    }
}