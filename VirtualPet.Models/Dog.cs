namespace VirtualPet.Models
{
    public class Dog :Animal, IAnimal
    {
        public Dog()
        {
            Type = AnimalTypes.Dog;
        }

        public override void Pet()
        {
            Happiness = (Happiness + AnimalDataUtilities.HappinessConfig()[AnimalTypes.Dog]);
        }

        public override void Feed()
        {
            Hunger = (Hunger - AnimalDataUtilities.FeedConfig()[AnimalTypes.Dog]);
        }
    }
}