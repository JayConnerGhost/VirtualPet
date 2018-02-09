using System.Collections.Generic;
using VirtualPet.Models;

namespace VirtualPet.Services
{
    public interface IPetFindService
    {
        IEnumerable<Pet> GetByUserId(string userName);
        Pet GetByIdentifier(PetIdentifier pet);
    }
}