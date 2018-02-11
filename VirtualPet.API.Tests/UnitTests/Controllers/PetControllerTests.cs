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
                var controller = new PetController(service);

                //act
                var result = controller.Get(userName);
                var count = result.Count();

                //assert
                count.Should().Be(2);
            }

            [Fact]
            public void Can_get_pet_for_user()
            {
                //arrange
                const string expectedPetName = "Tom";
                var userName = "jayconnerghost@gmail.com";
                var repository = new InMemoryPetRepository(PetDataUtilities.PetsData(userName));
                var service = new PetFindService(repository);
                var controller = new PetController(service);

                //act
                var result = controller.Get(userName);

                //assert
                var pet = result.First(x => x.Name == expectedPetName);
                pet.Name.Should().Be(expectedPetName);
            }

            [Fact]
            public void Pet_service_is_called()
            {
                //arrange
                const string expectedPetName = "freddy";
                const string userName = "jayconnerghost@gmail.com";
                var petService = Substitute.For<IPetFindService>();
                var returnedPet = new Pet {Name = "freddy"};
                var pets = new List<Pet> {returnedPet};
                petService.GetByUserId(userName).Returns(pets);
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
