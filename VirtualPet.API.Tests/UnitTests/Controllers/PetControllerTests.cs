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
                const string  userName="jayconnerghost@gmail.com";
                var preparedData = PrepareData(userName);
                var repository = new InMemoryPetRepository(preparedData);
                var service=new PetFindService(repository);
                var controller=new PetController(service);

                //act
                var result=controller.Get(userName);
                var count=result.Count();

                //assert
                count.Should().Be(2);
            }

            [Fact]
            public void Can_get_pet_for_user()
            {
                //arrange
                const string  expectedPetName= "spinny";
                var userName="jayconnerghost@gmail.com";
                var repository=new InMemoryPetRepository(PrepareData(userName));
                var service=new PetFindService(repository);
                var controller=new PetController(service);

                //act
                var result=controller.Get(userName);

                //assert
                var pet=result.First(x=>x.Name==expectedPetName);
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

            private IPets PrepareData(string userId)
            {
                return (Pets) new List<Pet>
                {
                    new Pet
                    {
                        Owner="test@rink.com",
                        Name = "freddy",
                        Type ="Cat"
                    },
                    new Pet
                    {
                        Owner="test@findr.com",
                        Name = "ted",
                        Type ="Snake"
                    },
                    new Pet
                    {
                        Owner="test@clink.com",
                        Name = "tom",
                        Type ="Dog"
                    },
                    new Pet
                    {
                        Owner=userId,
                        Name = "teddy",
                        Type ="Dog"
                    },
                    new Pet
                    {
                        Owner=userId,
                        Name = "spinny",
                        Type ="Gecko"
                    }

                };

            }
        }
    }
}
