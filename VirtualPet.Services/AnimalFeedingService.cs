using System;
using VirtualPet.Models;

namespace VirtualPet.Services
{
    public class AnimalFeedingService : IAnimalFeedingService
    {
        private readonly IAnimalFindService _animalFindService;

        public AnimalFeedingService(IAnimalFindService animalFindService)
        {
            _animalFindService = animalFindService;
        }

        public void Feed(AnimalIdentifier identifier)
        {
            _animalFindService.GetByIdentifier(identifier).Feed();
        }
    }
}