using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using VirtualPet.Models;
using Xunit;

namespace VirtualPet.API.Tests.UnitTests.Models
{
    public class LastFedTests
    {
        [Fact]
        public void When_fed_animal_lastFed_is_populated()
        {
            //arrange
            IAnimal animal = new Animal();
            //act
            animal.Feed();
            //assert
            animal.LastFed.Should().NotBeNull();
        }
    }
}
