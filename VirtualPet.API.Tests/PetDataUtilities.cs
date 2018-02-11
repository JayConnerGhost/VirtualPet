using VirtualPet.Models;

namespace VirtualPet.API.Tests
{
    public class PetDataUtilities
    {
        public static Pets PetsData(string userId)
        {
            return new Pets
            {
                new Pet
                {
                    Type="Cat",
                    Name="Tom",
                    Owner="fred@golf.com"
                },
                new Pet
                {
                    Type="Dog",
                    Name="Dave",
                    Owner="him@her.com"
                },
                new Pet
                {
                    Type="Cat",
                    Name="Tom",
                    Owner=userId
                },
                new Pet
                {
                    Type="Cat",
                    Name="eddy",
                    Owner=userId
                }
            };
        }
    }
}
