using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using VirtualPet.Models;
using Xunit;

namespace VirtualPet.API.Tests.AcceptanceTests.Startup
{
    public class ConfigurationTests
    {
        
        public class Seed: BaseWebTest
        {
           
            [Fact]
            public async Task Can_load_initialization_data()
            {
                //arrange
                const string expectedName="fred";

                //act
                var response = await _client.GetAsync("/api/pets/jayconnerghost@gmail.com");
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                //assert
                var pets = JsonConvert.DeserializeObject<IEnumerable<Pet>>(responseString);
                pets.First().Name.Should().Be(expectedName);

            }

        }
    }
}