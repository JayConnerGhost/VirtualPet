using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NSubstitute;
using VirtualPet.Models;
using VirtualPet.Services;
using VirtualPet.Web.Controllers;
using Xunit;

namespace VirtualPet.API.Tests.UnitTests
{
    public class PetController_Tests
    {
        public class Get
        {
            [Fact]
            public void Pet_service_is_called()
            {
                //arrange
                const string expectedPetName = "freddy";
                const string userName = "jayconnerghost@gmail.com";
                var petService = Substitute.For<IPetService>();
                var returnedPet = new Pet {Name = "freddy"};
                var pets = new List<Pet> {returnedPet};
                petService.Get(userName).Returns(pets);
                var controller = new PetController(petService);

                //act
                var result = controller.Get(userName);
                var pet = result.First();

                //assert
                pet.Name.Should().Be(expectedPetName);
            }
        }
    }
}
