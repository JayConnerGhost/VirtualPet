namespace VirtualPet.Models
{
    public class Cat :Animal, IAnimal
    {
        public Cat()
        {
            Type = AnimalTypes.Cat;
        }
        public override void Pet()
        {
            Happiness = (Happiness + AnimalDataUtilities.HappinessConfig()[AnimalTypes.Cat]);
        }

        public override void Feed()
        {
            Hunger = (Hunger - AnimalDataUtilities.FeedConfig()[AnimalTypes.Cat]);
        }
    }
}