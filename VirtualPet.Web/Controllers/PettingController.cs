using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualPet.Models;
using VirtualPet.Services;

namespace VirtualPet.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Petting")]
    public class PettingController : Controller
    {
        private readonly IAnimalsFindService _animalsFindingService;

        public PettingController(IAnimalsFindService animalsFindingService)
        {
            _animalsFindingService = animalsFindingService;
        }

        [HttpPut]
        public HttpResponseMessage Pet(AnimalIdentifier animal)
        {
            _animalsFindingService.GetByIdentifier(animal);
            
                
            
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
    }
}