using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using VirtualPet.Models;
using Xunit;

namespace VirtualPet.API.Tests.UnitTests.Models
{
     public class AnimalTests
    {
        public class Types
        {
            [Fact]
            public void Can_be_a_cat()
            {
                //arrange

                //act
                IAnimal animal = new Cat();

                //assert

            }
        }
       
    }
}
