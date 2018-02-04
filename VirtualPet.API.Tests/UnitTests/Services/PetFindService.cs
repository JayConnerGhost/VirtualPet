using FluentAssertions;
using NSubstitute;
using VirtualPet.Models;
using VirtualPet.Services;
using VirtualPet.Repositories;
using Xunit;
namespace VirtualPet.API.Tests.UnitTests.Services
{
    public class PetFindService
    {
      
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
        }
    }

  
}