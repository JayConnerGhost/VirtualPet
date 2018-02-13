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
    public class PettingControllerTests
    {
        public class Set
        {
            [Fact]
            public void Happiness_of_a_cat_increases_by_2_when_petted()
            {
                //arrange
                const string userId = "jayconnerghost@gmail.com";
                const string animalName= "eddy";
               
                var animalRepository=new InMemoryAnimalRepository(AnimalDataUtilities.AnimalData(userId));
                var animalFindService =new AnimalFindService(animalRepository);
                var animalController=new AnimalController(animalFindService);
                var pettingController=new PettingController(animalFindService,new AnimalPettingService(animalFindService,animalRepository));
                //act
                pettingController.Pet(new AnimalIdentifier
                {
                    AnimalName = animalName,
                    UserId = userId
                });
                
                //assert
                var animal=animalController.Get(userId,animalName);
                animal.Happiness.Should().Be(2);

            }
        }
    }
}
