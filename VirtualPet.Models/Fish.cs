namespace VirtualPet.Models
{
    public class Fish : Animal, IAnimal
    {
        public Fish()
        {
            Type = AnimalTypes.Fish;
        }

        public override void Pet()
        {
            Happiness = (Happiness + AnimalDataUtilities.HappinessConfig()[AnimalTypes.Fish]);
        }
        public override void Feed()
        {
            Hunger = (Hunger - AnimalDataUtilities.FeedConfig()[AnimalTypes.Fish]);
        }
    }
}