using System.Collections.Generic;

namespace VirtualPet.Models
{
    public class AnimalDataUtilities
    {
        public static AnimalHappinessValues HappinessConfig()
        {
           return new AnimalHappinessValues();
        }
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

    public class AnimalHappinessValues : Dictionary<AnimalTypes, int>
    {
        public AnimalHappinessValues()
        {
            this.Add(AnimalTypes.Cat,2);
            this.Add(AnimalTypes.Dog,1);
            this.Add(AnimalTypes.Snake,3);
            this.Add(AnimalTypes.Fish,4);
            this.Add(AnimalTypes.Lizard,5);
        }
    }
}
