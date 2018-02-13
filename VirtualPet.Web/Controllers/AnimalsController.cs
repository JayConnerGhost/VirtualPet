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
    [Route("api/Animals")]
    public class AnimalsController : Controller
    {
        private readonly IAnimalFindService _animalFindService;

        public AnimalsController(IAnimalFindService animalFindService)
        {
            _animalFindService = animalFindService;
        }
        
        // GET api/animals/fred@ted.com
        [HttpGet("{userName}")]
        public IEnumerable<IAnimal> Get(string userName)
        {
            return _animalFindService.GetByUserId(userName);
        }
    }
}