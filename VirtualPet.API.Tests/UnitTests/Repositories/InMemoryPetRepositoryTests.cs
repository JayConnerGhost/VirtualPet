using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using VirtualPet.Models;
using Xunit;

namespace VirtualPet.API.Tests.UnitTests.Repositories
{
     public class InMemoryPetRepositoryTests
    {
      
        public class GetByUserId
        {
            [Fact]
            public void Can_find_users_pets_by_userId()
            {
                //arrange
                var userId="test@tango.com";

                //act
                var count=new VirtualPet.Repositories.InMemoryPetRepository(new Pets
                {
                    new Pet
                      {
                          Owner="rinf@ted.com"
                      }  ,
                    new Pet
                      {
                          Owner="ging@yang.com"
                      },
                    new Pet
                      {
                          Owner=userId
                      },
                    new Pet
                    {
                        Owner=userId
                    },
                    new Pet
                    {
                        Owner=userId
                    },
                    new Pet
                    {
                        Owner=userId
                    }

                }).GetByUserId(userId).Count();


                //assert
                count.Should().Be(4);
            }

            [Fact]
            public void Can_find_users_pet_by_userId()
            {
                //arrange
                const string expectedPetName="freddy";
                const string  expectedPetType="Cat";
                const string userId = "test@tango.com";
                var listOfPets = new Pets
                {
                    new Pet
                    {
                        Name=expectedPetName,
                        Type=expectedPetType,
                        Owner=userId
                    }
                };

                //act
                var repository=new VirtualPet.Repositories.InMemoryPetRepository(listOfPets);
                var returnedPet=repository.GetByUserId(userId).First();



                //assert
                returnedPet.Name.Should().Be(expectedPetName);
                returnedPet.Type.Should().Be(expectedPetType);
            }
        }
    }
}
