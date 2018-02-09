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
        private readonly IPetFindService _petFindingService;

        public PettingController(IPetFindService petFindingService)
        {
            _petFindingService = petFindingService;
        }

        [HttpPut]
        public HttpResponseMessage Pet(PetIdentifier pet)
        {
            _petFindingService.GetByIdentifier(pet);
            
                
            
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
    }
}