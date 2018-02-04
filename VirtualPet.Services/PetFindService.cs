using System.Collections.Generic;
using VirtualPet.Models;

namespace VirtualPet.Services
{
    public class PetFindService:IPetFindService
    {
        public IEnumerable<Pet> GetByUserId(string userName)
        {
            throw new System.NotImplementedException();
        }
    }
}