using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using VirtualPet.Models;
using VirtualPet.Repositories;
using VirtualPet.Services;
using VirtualPet.Web.Controllers;
using Xunit;

namespace VirtualPet.API.Tests.UnitTests.Controllers
{
     public class FeedingControllerTests
     {
        public class Put
        {
            private InMemoryAnimalRepository animalFindRepository;
            private AnimalFindService animalFindService;
            private AnimalController animalController;
            private AnimalFeedingService animalFeedingService;
            private FeedingController feedingController;
            private const string UserId = "jayconnerghost@gmail.com";

            public Put()
            {
                animalFindRepository = new InMemoryAnimalRepository(AnimalDataUtilities.AnimalData(UserId));
                animalFindService = new AnimalFindService(animalFindRepository);
                animalController = new AnimalController(animalFindService);
                animalFeedingService = new AnimalFeedingService(animalFindService);
                feedingController = new FeedingController(animalFeedingService);
            }

            [Fact]
            public void Feeding_lizard_reduces_hunger_by_5()
            {
                //arrange
                const string LizardName = "tails";

                //check precondition 
                var lizardReference1 = animalController.Get(UserId, LizardName);
                lizardReference1.Hunger.Should().Be(0);

                //act
                feedingController.Feed(new AnimalIdentifier
                {
                    UserId = UserId,
                    AnimalName = LizardName
                });

                //assert
                var lizardReference2 = animalController.Get(UserId, LizardName);
                lizardReference2.Hunger.Should().Be(-5);
            }

            [Fact]
            public void Feeding_fish_reduces_hunger_by_4()
            {
                //arrange
                const string fishName = "zoom";

                //check precondition 
                var fishReference1 = animalController.Get(UserId, fishName);
                fishReference1.Hunger.Should().Be(0);

                //act
                feedingController.Feed(new AnimalIdentifier
                {
                    UserId = UserId,
                    AnimalName = fishName
                });

                //assert
                var fishReference2 = animalController.Get(UserId, fishName);
                fishReference2.Hunger.Should().Be(-4);
            }

            [Fact]
            public void Feeding_snake_reduces_hunger_by_3()
            {
                //arrange
                const string snakeName = "strike";

                //check precondition 
                var snakeReference1 = animalController.Get(UserId, snakeName);
                snakeReference1.Hunger.Should().Be(0);

                //act
                feedingController.Feed(new AnimalIdentifier
                {
                    UserId = UserId,
                    AnimalName = snakeName
                });

                //assert
                var snakeReference2 = animalController.Get(UserId, snakeName);
                snakeReference2.Hunger.Should().Be(-3);
            }

            [Fact]
            public void Feeding_dog_reduces_hunger_by_1()
            {
                //arrange
                const string dogName = "tommy";

                //check precondition 
                var dogReference1 = animalController.Get(UserId, dogName);
                dogReference1.Hunger.Should().Be(0);

                //act
                feedingController.Feed(new AnimalIdentifier
                {
                    UserId = UserId,
                    AnimalName = dogName
                });

                //assert
                var dogReference2 = animalController.Get(UserId, dogName);
                dogReference2.Hunger.Should().Be(-1);
            }

            [Fact]
            public void Feeding_cat_reduces_hunger_by_2()
            {
                //arrange
                const string animalName = "eddy";

                //check precondition 
                var catReference1 = animalController.Get(UserId, animalName);
                catReference1.Hunger.Should().Be(0);

                //act
                feedingController.Feed(new AnimalIdentifier
                {
                    UserId = UserId,
                    AnimalName = animalName
                });

                //assert
                var catReference2 = animalController.Get(UserId, animalName);
                catReference2.Hunger.Should().Be(-2);

            }

            [Fact]
            public void Can_Feed_animal()
            {
                //arrange
                const string animalName = "Tom";

                //check precondition 
                var animalReference1 = animalController.Get(UserId, animalName);
                animalReference1.Hunger.Should().Be(0);

                //act
                feedingController.Feed(new AnimalIdentifier
                {
                    UserId = UserId,
                    AnimalName = animalName
                });

                //assert
                var animalReference2 = animalController.Get(UserId, animalName);
                animalReference2.Hunger.Should().Be(-2);
            }
        }
    }
}
