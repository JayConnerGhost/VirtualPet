using VirtualPet.Models;

namespace VirtualPet.Services
{
    public interface IAnimalPettingService
    {
        void Pet(AnimalIdentifier animalIdentifier);
    }
}