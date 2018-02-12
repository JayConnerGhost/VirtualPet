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

        private readonly IAnimalsFindService _animalsFindService;

        public AnimalController(IAnimalsFindService animalsFindService)
        {
            _animalsFindService = animalsFindService;
        }

        [Route("{userId}/{animalName}")]
        [HttpGet()]
        public IAnimal Get(string userId, string animalName)
        {
            return _animalsFindService.GetByIdentifier(new AnimalIdentifier
            {
                AnimalName = animalName,
                UserId = userId
            });
            
        }
    }

 

}