using System;
using System.Collections.Generic;
using System.Text;
using VirtualPet.Models;
using VirtualPet.Repositories;
using VirtualPet.Services;
using VirtualPet.Web.Controllers;
using Xunit;

namespace VirtualPet.API.Tests.UnitTests.Controllers
{
    public class PettingControllerTests
    {
        public class Set
        {
            [Fact]
            public void Happiness_of_pet_increases_when_petted()
            {
                //arrange
                const string ownerId="yim@test.com";
                const string petName="ted";
                var pet = new Pet
                {
                    Name = petName,
                    Owner = ownerId,
                    Type = "Cat",
                    Happiness = 0.0
                };
                //act
               
                //assert
              

            }
        }
    }
}
