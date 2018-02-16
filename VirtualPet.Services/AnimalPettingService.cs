using System;
using System.ComponentModel.DataAnnotations;
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
         
            DateTime animalLastPettedAsDateTime = animal.LastPetted ?? DateTime.MinValue;

            if (animalLastPettedAsDateTime == DateTime.MinValue)
            {
                animal.Pet();
                animal.Happiness = (AnimalDataUtilities.HappinessConfig()[animal.Type]);
                return;
            }
            
            animal.Happiness = (animal.Happiness+AnimalDataUtilities.HappinessConfig()[animal.Type]);
            animal.Pet();
        }
    }
}