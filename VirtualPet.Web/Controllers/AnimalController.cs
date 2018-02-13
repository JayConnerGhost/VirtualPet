using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualPet.Models;
using VirtualPet.Services;

namespace VirtualPet.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/animal")]
    public class AnimalController : Controller
    {

        private readonly IAnimalFindService _animalFindService;

        public AnimalController(IAnimalFindService animalFindService)
        {
            _animalFindService = animalFindService;
        }

        [Route("{userId}/{animalName}")]
        [HttpGet()]
        public IAnimal Get(string userId, string animalName)
        {
            return _animalFindService.GetByIdentifier(new AnimalIdentifier
            {
                AnimalName = animalName,
                UserId = userId
            });
            
        }
    }

 

}