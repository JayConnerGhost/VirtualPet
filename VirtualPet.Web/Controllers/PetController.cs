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
    [Route("api/Pet")]
    public class PetController : Controller
    {
        private readonly IPetFindService _petFindService;

        public PetController(IPetFindService petFindService)
        {
            _petFindService = petFindService;
        }

        // GET api/pet/fred@ted.com
        [HttpGet("{userName}")]
        public IEnumerable<Pet> Get(string userName)
        {
            return _petFindService.GetByUserId(userName);
        }
    }
}