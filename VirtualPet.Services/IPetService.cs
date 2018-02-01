using System.Collections.Generic;
using VirtualPet.Models;

namespace VirtualPet.Services
{
    public interface IPetService
    {
        IEnumerable<Pet> Get(string userName);
    }

    public class PetService:IPetService
    {
        public IEnumerable<Pet> Get(string userName)
        {
            throw new System.NotImplementedException();
        }
    }
}