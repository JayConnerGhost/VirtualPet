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
    [Route("api/Pets")]
    public class PetsController : Controller
    {
        private readonly IPetFindService _petFindService;

        public PetsController(IPetFindService petFindService)
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