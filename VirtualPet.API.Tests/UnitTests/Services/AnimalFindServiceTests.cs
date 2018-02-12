using System.Linq;
using FluentAssertions;
using NSubstitute;
using VirtualPet.Models;
using VirtualPet.Repositories;
using Xunit;
namespace VirtualPet.API.Tests.UnitTests.Services
{
    public class AnimalFindServiceTests
    {
        public class GetByAnimalIdentifier
        {
            [Fact]
            public void Repository_is_called_when_finding_a_Animal_by_AnimalIdentifier()
            {
                //arrange
                const string animalName="ted";
                const string userId="test@test.com";
                var repository=Substitute.For<IAnimalRepository>();
                var service =new VirtualPet.Services.AnimalFindService(repository);

                //act
                var identifier = new AnimalIdentifier
                {
                    UserId = userId,
                    AnimalName = animalName
                };
                service.GetByIdentifier(identifier);

                //assert
                repository.ReceivedWithAnyArgs().GetByUserIdandAnimalName(Arg.Any<string>(), Arg.Any<string>());
            }

            [Fact]
            public void Can_find_animal_by_userId_and_AnimalName()
            {
                //arrange
                const string name = "Tom";
                const string userId = "test@test.com";
                const AnimalTypes type = AnimalTypes.Cat;
                var repository =new InMemoryAnimalRepository(AnimalDataUtilities.AnimalData(userId));
                var service = new VirtualPet.Services.AnimalFindService(repository);
                //act
                var returnedAnimal=service.GetByIdentifier(new AnimalIdentifier
                {
                    AnimalName=name,
                    UserId=userId
                } );

                //assert
                returnedAnimal.Name.Should().Be(name);
                returnedAnimal.Owner.Should().Be(userId);
                returnedAnimal.Type.Should().Be(type);

            }
        }
      
        public class GetByUserId
        {
            [Fact]
            public void Repository_is_called_when_finding_a_pet_by_userId()
            {
                //arrange
                var repository = Substitute.For<IAnimalRepository>();
                var service=new VirtualPet.Services.AnimalFindService(repository);
                
                //act
                var returnedAnimal = service.GetByUserId("2");
                
                //assert
                repository.ReceivedWithAnyArgs().GetByUserId(Arg.Any<string>());
            }

            [Fact]
            public void Can_find_animals_by_userId()
            {
                const string userId="test@tang.com";
                //arrange + act
                var count= new VirtualPet.Services.AnimalFindService(new InMemoryAnimalRepository(AnimalDataUtilities.AnimalData(userId)
                )).GetByUserId(userId).Count();
                
                //Assert
                count.Should().Be(2);
            }

            
        }
    }

  
}