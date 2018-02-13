using System.Collections.Generic;
using VirtualPet.Models;

namespace VirtualPet.Services
{
    public interface IAnimalFindService
    {
        IEnumerable<IAnimal> GetByUserId(string userName);
        IAnimal GetByIdentifier(AnimalIdentifier animal);
    }
}