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
              
                const string animalName = "eddy";

                //act
                pettingController.Pet(new AnimalIdentifier
                {
                    AnimalName = animalName,
                    UserId = UserId
                });

                //assert
                var animal = animalController.Get(UserId, animalName);
                animal.Happiness.Should().Be(2);

            }

            [Fact]
            public void Happiness_of_a_cat_increases_by_2_when_petted()
            {
                //arrange
              
                const string animalName= "tommy";
               
                var animalRepository=new InMemoryAnimalRepository(AnimalDataUtilities.AnimalData(UserId));
                var animalFindService =new AnimalFindService(animalRepository);
                var animalController=new AnimalController(animalFindService);
                var pettingController=new PettingController(animalFindService,new AnimalPettingService(animalFindService,animalRepository));
                //act
                pettingController.Pet(new AnimalIdentifier
                {
                    AnimalName = animalName,
                    UserId = UserId
                });
                
                //assert
                var animal=animalController.Get(UserId,animalName);
                animal.Happiness.Should().Be(1);

            }

            [Fact]
            public void Happiness_of_a_lizard_increases_by_5_when_petted()
            {
                //arrange
                
                const string animalName = "tails";

                var animalRepository = new InMemoryAnimalRepository(AnimalDataUtilities.AnimalData(UserId));
                var animalFindService = new AnimalFindService(animalRepository);
                var animalController = new AnimalController(animalFindService);
                var pettingController = new PettingController(animalFindService, new AnimalPettingService(animalFindService, animalRepository));
                //act
                pettingController.Pet(new AnimalIdentifier
                {
                    AnimalName = animalName,
                    UserId = UserId
                });

                //assert
                var animal = animalController.Get(UserId, animalName);
                animal.Happiness.Should().Be(5);

            }
            [Fact]
            public void Happiness_of_a_snake_increases_by_3_when_petted()
            {
                //arrange
     
                const string animalName = "strike";

                var animalRepository = new InMemoryAnimalRepository(AnimalDataUtilities.AnimalData(UserId));
                var animalFindService = new AnimalFindService(animalRepository);
                var animalController = new AnimalController(animalFindService);
                var pettingController = new PettingController(animalFindService, new AnimalPettingService(animalFindService, animalRepository));
                //act
                pettingController.Pet(new AnimalIdentifier
                {
                    AnimalName = animalName,
                    UserId = UserId
                });

                //assert
                var animal = animalController.Get(UserId, animalName);
                animal.Happiness.Should().Be(3);

            }
            [Fact]
            public void Happiness_of_a_fish_increases_by_4_when_petted()
            {
                //arrange
     
                const string animalName = "zoom";

                var animalRepository = new InMemoryAnimalRepository(AnimalDataUtilities.AnimalData(UserId));
                var animalFindService = new AnimalFindService(animalRepository);
                var animalController = new AnimalController(animalFindService);
                var pettingController = new PettingController(animalFindService, new AnimalPettingService(animalFindService, animalRepository));
                //act
                pettingController.Pet(new AnimalIdentifier
                {
                    AnimalName = animalName,
                    UserId = UserId
                });

                //assert
                var animal = animalController.Get(UserId, animalName);
                animal.Happiness.Should().Be(4);

            }
        }
    }
}
