﻿using System;
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
    [Route("api/pet")]
    public class PetController : Controller
    {

        private readonly IPetFindService _petFindService;

        public PetController(IPetFindService petFindService)
        {
            _petFindService = petFindService;
        }

        [Route("{userId}/{petName}")]
        [HttpGet()]
        public Pet Get(string userId, string petName)
        {
            return _petFindService.GetByIdentifier(new PetIdentifier
            {
                PetName = petName,
                UserId = userId
            });
            
        }
    }

 

}