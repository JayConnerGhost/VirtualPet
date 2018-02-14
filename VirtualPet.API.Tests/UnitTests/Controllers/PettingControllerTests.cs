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
        public class Put
        {
            InMemoryAnimalRepository animalRepository;
            AnimalFindService animalFindService;
            AnimalController animalController;
            PettingController pettingController;
            const string UserId = "jayconnerghost@gmail.com";

            public Put()
            {
                animalRepository = new InMemoryAnimalRepository(AnimalDataUtilities.AnimalData(UserId));
                animalFindService = new AnimalFindService(animalRepository);
                animalController = new AnimalController(animalFindService);
                pettingController = new PettingController(animalFindService, new AnimalPettingService(animalFindService, animalRepository));
            }

            [Fact]
            public void Happiness_of_a_dog_increases_by_1_when_petted()
            {
                //arrange
              
                const string dogName = "eddy";

                //act
                pettingController.Pet(new AnimalIdentifier(UserId, dogName));
               

                //assert
                var animal = animalController.Get(UserId, dogName);
                animal.Happiness.Should().Be(2);

            }

            [Fact]
            public void Happiness_of_a_cat_increases_by_2_when_petted()
            {
                //arrange
                const string catName= "tommy";
               
                  //act
                pettingController.Pet(new AnimalIdentifier(UserId, catName));
              
                //assert
                var animal=animalController.Get(UserId,catName);
                animal.Happiness.Should().Be(1);

            }

            [Fact]
            public void Happiness_of_a_lizard_increases_by_5_when_petted()
            {
                //arrange
                
                const string lizardName = "tails";
                
                //act
                pettingController.Pet(new AnimalIdentifier(UserId,lizardName));
                
                //assert
                var animal = animalController.Get(UserId, lizardName);
                animal.Happiness.Should().Be(5);

            }
            [Fact]
            public void Happiness_of_a_snake_increases_by_3_when_petted()
            {
                //arrange
     
                const string snakeName = "strike";
                //act
                pettingController.Pet(new AnimalIdentifier(UserId, snakeName));
                
                //assert
                var animal = animalController.Get(UserId, snakeName);
                animal.Happiness.Should().Be(3);

            }
            [Fact]
            public void Happiness_of_a_fish_increases_by_4_when_petted()
            {
                //arrange
     
                const string fishName = "zoom";
                
                //act
                pettingController.Pet(new AnimalIdentifier(UserId, fishName));
                
                //assert
                var animal = animalController.Get(UserId, fishName);
                animal.Happiness.Should().Be(4);

            }
        }
    }
}
