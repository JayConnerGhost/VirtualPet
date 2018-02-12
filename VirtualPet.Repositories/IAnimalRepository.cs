using System.Collections.Generic;
using VirtualPet.Models;

namespace VirtualPet.Repositories
{
    public interface IAnimalRepository
    {
        IEnumerable<IAnimal> GetByUserId(string userName);
        IAnimal GetByUserIdandAnimalName(string userName, string petName);
    }
}
