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
        public async Task Can_get_pet_by_user_email_address()
        {
            //arrange
            const string  expectedOwner="jayconnerghost@gmail.com";
            const string expectedName = "fred";
            const string expectedType="Dog";

            //act
            var response = await _client.GetAsync("/api/pets/jayconnerghost@gmail.com");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            
            //assert
            var pets = JsonConvert.DeserializeObject<IEnumerable<Pet>>(responseString);
            pets.First().Name.Should().Be(expectedName);
            pets.First().Owner.Should().Be(expectedOwner);
            pets.First().Type.Should().Be(expectedType);
        }

        [Fact]
        public async Task Can_get_pet_by_owner_email_and_name()
        {
            //arrange
            const string expectedOwner = "jayconnerghost@gmail.com";
            const string expectedName = "fred";
            const string expectedType = "Dog";

            //act
            var response = await _client.GetAsync("/api/pet/jayconnerghost%40gmail.com/fred");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            //assert
            var pets = JsonConvert.DeserializeObject<Pet>(responseString);
            pets.Name.Should().Be(expectedName);
            pets.Owner.Should().Be(expectedOwner);
            pets.Type.Should().Be(expectedType);
        }

    }
}