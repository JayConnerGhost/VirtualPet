using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NSubstitute;
using VirtualPet.Models;
using VirtualPet.Services;
using VirtualPet.Repositories;
using Xunit;
namespace VirtualPet.API.Tests.UnitTests.Services
{
    public class PetFindServiceTests
    {
        public class GetByPetIdentifier
        {
            [Fact]
            public void Repository_is_called_when_finding_a_pet_by_PetIdentifier()
            {
                //arrange
                const string petName="ted";
                const string userId="test@test.com";
                var petRepository=Substitute.For<IPetRepository>();
                var service =new VirtualPet.Services.PetFindService(petRepository);

                //act
                var petIdentifier = new PetIdentifier
                {
                    UserId = userId,
                    PetName = petName
                };
                service.GetByIdentifier(petIdentifier);

                //assert
                petRepository.ReceivedWithAnyArgs().GetByUserIdandPetName(Arg.Any<string>(), Arg.Any<string>());
            }

            [Fact]
            public void Can_find_pet_by_userId_and_PetName()
            {
                //arrange
                const string petName = "Tom";
                const string userId = "test@test.com";
                const string petType = "Cat";
                var petRepository =new InMemoryPetRepository(PetDataUtilities.PetsData(userId));
                var service = new VirtualPet.Services.PetFindService(petRepository);
                //act
                var returnedPet=service.GetByIdentifier(new PetIdentifier
                {
                    PetName=petName,
                    UserId=userId
                } );

                //assert
                returnedPet.Name.Should().Be(petName);
                returnedPet.Owner.Should().Be(userId);
                returnedPet.Type.Should().Be(petType);

            }
        }
      
        public class GetByUserId
        {
            [Fact]
            public void Repository_is_called_when_finding_a_pet_by_userId()
            {
                //arrange
                var petRepository = Substitute.For<IPetRepository>();
                var service=new VirtualPet.Services.PetFindService(petRepository);
                
                //act
                var returnedPet = service.GetByUserId("2");
                
                //assert
                petRepository.ReceivedWithAnyArgs().GetByUserId(Arg.Any<string>());
            }

            [Fact]
            public void Can_find_pets_by_userId()
            {
                const string userId="test@tang.com";
                //arrange + act
                var count= new VirtualPet.Services.PetFindService(new InMemoryPetRepository(PetDataUtilities.PetsData(userId)
                )).GetByUserId(userId).Count();
                
                //Assert
                count.Should().Be(2);
            }

            
        }
    }

  
}