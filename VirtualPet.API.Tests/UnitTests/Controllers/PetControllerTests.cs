using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using VirtualPet.Repositories;
using VirtualPet.Services;
using VirtualPet.Web.Controllers;
using Xunit;

namespace VirtualPet.API.Tests.UnitTests.Controllers
{
    public class PetControllerTests
    {
        [Fact]
        public void Can_retrieve_a_pet()
        {
            //arrange
            const string petName = "Tom";
            const string owner = "jay@codegenie.com";
            const string type = "Cat";

            var repository = new InMemoryPetRepository(PetDataUtilities.PetsData(owner));
            var service = new PetFindService(repository);
            var controller=new PetController(service);

            //act
            var returnedPet=controller.Get(owner,petName);



            //Assert
            returnedPet.Name.Should().Be(petName);
            returnedPet.Owner.Should().Be(owner);
            returnedPet.Type.Should().Be(type);
        }
    }
}
