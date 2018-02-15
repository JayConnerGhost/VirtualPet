using FluentAssertions;
using VirtualPet.Models;
using Xunit;

namespace VirtualPet.API.Tests.UnitTests.Models
{
    public class LastPettedTests
    {
        [Fact]
        public void When_petted_animal_lastPetted_is_populated()
        {
            //arrange
            IAnimal animal=new Animal();

            //act
            animal.Pet();
           
            //Assert
            animal.LastPetted.Should().NotBeNull();

        }
    }
}