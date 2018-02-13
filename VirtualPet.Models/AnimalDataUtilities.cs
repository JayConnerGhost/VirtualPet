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
                },
                new Dog
                {
                    Type=AnimalTypes.Dog,
                    Name="tommy",
                    Owner=userId
                },
                new Snake
                {
                    Type=AnimalTypes.Snake,
                    Name="strike",
                    Owner=userId
                },
                new Lizard
                {
                    Type=AnimalTypes.Lizard,
                    Name="tails",
                    Owner=userId
                },
                new Fish
                {
                    Type=AnimalTypes.Fish,
                    Name="zoom",
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
