using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using VirtualPet.Models;
using VirtualPet.Repositories;
using VirtualPet.Services;
using VirtualPet.Web.Controllers;
using Xunit;

namespace VirtualPet.API.Tests.UnitTests.Controllers
{
    public class AnimalControllerTests
    {
        [Fact]
        public void Can_retrieve_a_animal()
        {
            //arrange
            const string animalName = "Tom";
            const string owner = "jay@codegenie.com";
            const AnimalTypes type =AnimalTypes.Cat;

            var repository = new InMemoryAnimalRepository(AnimalDataUtilities.AnimalData(owner));
            var service = new AnimalFindService(repository);
            var controller=new AnimalController(service);

            //act
            var animal=controller.Get(owner,animalName);



            //Assert
            animal.Name.Should().Be(animalName);
            animal.Owner.Should().Be(owner);
            animal.Type.Should().Be(type);
        }
    }
}
