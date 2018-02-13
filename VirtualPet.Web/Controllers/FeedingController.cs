using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualPet.Models;
using VirtualPet.Services;

namespace VirtualPet.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Feeding")]
    public class FeedingController : Controller
    {
        private readonly IAnimalFeedingService _animalFeedingService;

        public FeedingController(IAnimalFeedingService animalFeedingService)
        {
            _animalFeedingService = animalFeedingService;
        }

        [HttpPut]
        public HttpResponseMessage Feed(AnimalIdentifier identifier)
        {
            _animalFeedingService.Feed(identifier);
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
    }
}