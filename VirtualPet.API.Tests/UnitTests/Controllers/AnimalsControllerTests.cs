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
     public class AnimalsControllerTests
    {
        public class Get
        {
            [Fact]
            public void Can_get_animals_for_user()
            {
                //arrange
                const string userName = "jayconnerghost@gmail.com";
                var preparedData = AnimalDataUtilities.AnimalData(userName);
                var repository = new InMemoryAnimalRepository(preparedData);
                var service = new AnimalFindService(repository);
                var controller = new AnimalsController(service);

                //act
                var result = controller.Get(userName);
                var count = result.Count();

                //assert
                count.Should().Be(2);
            }

           
        }
    }
}
