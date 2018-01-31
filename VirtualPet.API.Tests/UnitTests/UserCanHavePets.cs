using FluentAssertions;
using VirtualPet.Web.Controllers;
using Xunit;

namespace VirtualPet.API.Tests.UnitTests
{
    public class UserCanHavePets
    {
        [Fact]
        public void Find_pets_by_userName()
        {
            //arrange
            const string expectedPetName = "freddy";
            const string userName = "jayconnerghost@gmail.com";
            var controller=new PetController();

            //act
            var result=controller.Get(userName);

            //assert
            result.Should().Be(expectedPetName);
        }
    }

   
}
