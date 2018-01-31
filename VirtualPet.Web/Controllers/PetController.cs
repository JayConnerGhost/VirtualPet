using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VirtualPet.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Pet")]
    public class PetController : Controller
    {
        // GET api/pet/fred@ted.com
        [HttpGet("{userName}")]
        public string Get(string userName)
        {
            return string.Empty;
        }
    }
}