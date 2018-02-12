using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using VirtualPet.Models;
using Xunit;

namespace VirtualPet.API.Tests.AcceptanceTests
{
    public class Get:BaseWebTest
    {
        [Fact]
        public async Task Can_get_animal_by_user_email_address()
        {
            //arrange
            const string  expectedOwner="jayconnerghost@gmail.com";
            const string expectedName = "fred";
            const AnimalTypes expectedType=AnimalTypes.Cat;

            //act
            var response = await _client.GetAsync("/api/animals/jayconnerghost@gmail.com");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            
            //assert
            var animals = JsonConvert.DeserializeObject<IEnumerable<Animal>>(responseString);
            animals.First().Name.Should().Be(expectedName);
            animals.First().Owner.Should().Be(expectedOwner);
            animals.First().Type.Should().Be(expectedType);
        }

        [Fact]
        public async Task Can_get_pet_by_owner_email_and_name()
        {
            //arrange
            const string expectedOwner = "jayconnerghost@gmail.com";
            const string expectedName = "fred";
            const AnimalTypes expectedType = AnimalTypes.Cat;

            //act
            var response = await _client.GetAsync("/api/animal/jayconnerghost%40gmail.com/fred");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            //assert
            var animals = JsonConvert.DeserializeObject<Animal>(responseString);
            animals.Name.Should().Be(expectedName);
            animals.Owner.Should().Be(expectedOwner);
            animals.Type.Should().Be(expectedType);
        }

    }
}