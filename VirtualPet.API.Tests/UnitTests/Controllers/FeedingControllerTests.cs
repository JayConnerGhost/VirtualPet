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
    public class FeedingControllerTests
    {
        [Fact]
        public void Can_Feed_animal()
        {
            //arrange
            const string userId="jayconnerghost@gmail.com";
            const string animalName = "Tom";
            var animalFindRepository = new InMemoryAnimalRepository(AnimalDataUtilities.AnimalData(userId));
            var animalFindService = new AnimalFindService(animalFindRepository);
            var animalController=new AnimalController(animalFindService);
            var animalFeedingService = new AnimalFeedingService(animalFindService);
            var feedingController=new FeedingController(animalFeedingService);

            //check precondition 
            var animalReference1 = animalController.Get(userId, animalName);
            animalReference1.Hunger.Should().Be(0);

            //act
            feedingController.Feed(new AnimalIdentifier
            {
                UserId = userId,
                AnimalName = animalName
            });

            //assert
            var animalReference2=animalController.Get(userId, animalName);
            animalReference2.Hunger.Should().Be(-1);
        }
    }
}
