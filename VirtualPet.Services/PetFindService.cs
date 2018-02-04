using System.Collections.Generic;
using VirtualPet.Models;
using VirtualPet.Repositories;

namespace VirtualPet.Services
{
    public class PetFindService:IPetFindService
    {
        private readonly IPetRepository _petRepository;

        public PetFindService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public IEnumerable<Pet> GetByUserId(string userName)
        {
           return _petRepository.GetByUserId(userName);
        }
    }
}