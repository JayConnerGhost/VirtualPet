using VirtualPet.Models;

namespace VirtualPet.API.Tests
{
    public class AnimalDataUtilities
    {
        public static Animals AnimalData(string userId)
        {
            return new Animals
            {
                new Cat
                {
                    Type=AnimalTypes.Cat,
                    Name="Tom",
                    Owner="fred@golf.com"
                },
                new Cat
                {
                    Type=AnimalTypes.Cat,
                    Name="Dave",
                    Owner="him@her.com"
                },
                new Cat
                {
                    Type=AnimalTypes.Cat,
                    Name="Tom",
                    Owner=userId
                },
                new Cat
                {
                    Type=AnimalTypes.Cat,
                    Name="eddy",
                    Owner=userId
                }
            };
        }
    }
}
