using System.Collections.Generic;
using VirtualPet.Models;

namespace VirtualPet.Repositories
{
    public interface IPetRepository
    {
        IEnumerable<Pet> GetByUserId(string userName);
        Pet GetByUserIdandPetName(string UserName, string petName);
    }
}
