using FluentAssertions;
using VirtualPet.Models;
using VirtualPet.Repositories;
using VirtualPet.Services;
using Xunit;

namespace VirtualPet.API.Tests.UnitTests.Services
{
    public class PettingAnimalService
    {
        public class Pet
        {
            [Fact]
            public void Animal_happiness_increases_when_petted()
            {
                //arrange
                const string userId="jayconnerghost@gmail.com";
                const string animalName="eddy";
                var data = AnimalDataUtilities.AnimalData(userId);
                var inMemoryAnimalRepository = new InMemoryAnimalRepository(data);
                var animalFindService = new AnimalFindService(inMemoryAnimalRepository);
                var animalPettingService = new AnimalPettingService(animalFindService, inMemoryAnimalRepository);
                //preCondition-Check
                var petPrePetting = animalFindService.GetByIdentifier(new AnimalIdentifier(userId, animalName));
                petPrePetting.Happiness.Should().Be(0);

                //act
                animalPettingService.Pet(new AnimalIdentifier(userId,animalName));
               
                //assert
                var petPostPetting = animalFindService.GetByIdentifier(new AnimalIdentifier(userId,animalName));
    
                petPostPetting.Happiness.Should().Be(2);
            }
        }
    }
}