using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualPet.Models;
using VirtualPet.Services;

namespace VirtualPet.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Petting")]
    public class PettingController : Controller
    {
        private readonly IAnimalFindService _animalFindingService;
        private readonly IAnimalPettingService _animalPettingService;

        public PettingController(IAnimalFindService animalFindingService, IAnimalPettingService animalPettingService)
        {
            _animalFindingService = animalFindingService;
            _animalPettingService = animalPettingService;
        }

        [HttpPut]
        public HttpResponseMessage Pet(AnimalIdentifier animal)
        {
            _animalPettingService.Pet(animal);
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
    }
}