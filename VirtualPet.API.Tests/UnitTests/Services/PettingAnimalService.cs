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
            public void Pet_happiness_increases_when_petted()
            {
                //arrange
                const string userId="jayconnerghost@gmail.com";
                const string petName="eddy";
                var data = AnimalDataUtilities.AnimalData(userId);
                var petFindService = new AnimalFindService(new InMemoryAnimalRepository(data));

                //preCondition-Check
                var petPrePetting = petFindService.GetByIdentifier(new AnimalIdentifier
                {
                    UserId = userId,
                    AnimalName = petName
                });
                petPrePetting.Happiness.Should().Be(0);
                //act



                //assert
                var petPostPetting = petFindService.GetByIdentifier(new AnimalIdentifier
                {
                    UserId = userId,
                    AnimalName = petName
                });
                petPostPetting.Happiness.Should().Be(1);
            }
        }
    }
}