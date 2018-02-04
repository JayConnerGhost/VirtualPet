using FluentAssertions;
using NSubstitute;
using VirtualPet.Models;
using VirtualPet.Services;
using Xunit;
namespace VirtualPet.API.Tests.UnitTests.Services
{
    public class PetFindService
    {
        public class GetByUserId
        {
            [Fact]
            public void Can_locate_pets_by_userId()
            {
                //arrange
                var expectedName = "freddy";
                
                
                //act
                Pet returnedPet=new Pet();


                //assert
                returnedPet.Should().BeOfType<Pet>();
                returnedPet.Name.Should().Be(expectedName);
            }
        }
    }
}