using System;
using System.Collections.Generic;
using VirtualPet.Models;

namespace VirtualPet.Repositories
{
    public class PetRepository : IPetRepository
    {
        public IEnumerable<Pet> GetByUserId(string userName)
        {
            throw new NotImplementedException();
        }
    }
}