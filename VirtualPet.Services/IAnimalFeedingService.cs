using VirtualPet.Models;

namespace VirtualPet.Services
{
    public interface IAnimalFeedingService
    {
        void Feed(AnimalIdentifier identifier);
    }
}