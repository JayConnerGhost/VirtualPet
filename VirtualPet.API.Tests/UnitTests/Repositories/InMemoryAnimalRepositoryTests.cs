using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using VirtualPet.API.Tests.UnitTests.Models;
using VirtualPet.Models;
using Xunit;

namespace VirtualPet.API.Tests.UnitTests.Repositories
{
     public class InMemoryAnimalRepositoryTests
    {
      
        public class GetByUserId
        {
            [Fact]
            public void Can_find_users_animals_by_userId()
            {
                //arrange
                var userId="test@tango.com";

                //act
                var count=new VirtualPet.Repositories.InMemoryAnimalRepository(new Animals
                {
                    new Cat
                      {
                          Owner="rinf@ted.com"
                      }  ,
                    new Cat
                      {
                          Owner="ging@yang.com"
                      },
                    new Cat
                      {
                          Owner=userId
                      },
                    new Cat
                    {
                        Owner=userId
                    },
                    new Cat
                    {
                        Owner=userId
                    },
                    new Cat
                    {
                        Owner=userId
                    }

                }).GetByUserId(userId).Count();


                //assert
                count.Should().Be(4);
            }

            [Fact]
            public void Can_find_users_Animal_by_userId()
            {
                //arrange
                const string expectedAnimalName="freddy";
                const AnimalTypes expectedAnimalType = AnimalTypes.Cat;
                const string userId = "test@tango.com";
                var listOfAnimals = new Animals
                {
                    new Cat
                    {
                        Name=expectedAnimalName,
                        Type=AnimalTypes.Cat,
                        Owner=userId
                    }
                };

                //act
                var repository=new VirtualPet.Repositories.InMemoryAnimalRepository(listOfAnimals);
                var animal=repository.GetByUserId(userId).First();



                //assert
                animal.Name.Should().Be(expectedAnimalName);
                animal.Type.Should().Be(expectedAnimalType);
            }
        }
    }
}
