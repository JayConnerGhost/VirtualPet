using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace VirtualPet.API.Tests.UnitTests.Models
{
    public class Pet
    {
        public class Equality
        {
            [Fact]
            public void Can_compare_pet_by_name_and_type()
            {
                //arrange
                var pet1 = new VirtualPet.Models.Pet
                {
                    Name = "ted",
                    Type = "snake"
                };
                var pet2=new VirtualPet.Models.Pet
                {
                    Name = "ted",
                    Type = "snake"
                };

                //act
                var result = pet1.Equals(pet2);

                //assert
                result.Should().BeTrue();
            }
        }
    }
}
