using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NSubstitute;
using VirtualPet.Models;
using VirtualPet.Repositories;
using VirtualPet.Services;
using VirtualPet.Web.Controllers;
using Xunit;

namespace VirtualPet.API.Tests.UnitTests.Controllers
{
     public class PetControllerTests
    {
        public class Get
        {
            [Fact]
            public void Can_get_pets_for_user()
            {
                //arrange
                const string userName = "jayconnerghost@gmail.com";
                var preparedData = PetDataUtilities.PetsData(userName);
                var repository = new InMemoryPetRepository(preparedData);
                var service = new PetFindService(repository);
                var controller = new PetsController(service);

                //act
                var result = controller.Get(userName);
                var count = result.Count();

                //assert
                count.Should().Be(2);
            }

           
        }
    }
}
