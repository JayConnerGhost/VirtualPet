﻿using System;
using System.Collections.Generic;
using VirtualPet.Models;

namespace VirtualPet.Repositories
{
    public class InMemoryPetRepository : IPetRepository
    {
        private readonly List<Pet> _listOfPets;

        public InMemoryPetRepository(IPets listOfPets)
        {
            _listOfPets = (List<Pet>) listOfPets;
        }

        public IEnumerable<Pet> GetByUserId(string userName)
        {
           return _listOfPets.FindAll(x => x.Owner == userName);
        }
    }
}