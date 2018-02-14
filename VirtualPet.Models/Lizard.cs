namespace VirtualPet.Models
{
    public class Lizard : Animal, IAnimal
    {
        public Lizard()
        {
            Type = AnimalTypes.Lizard;
        }

        public override void Pet()
        {
            Happiness = (Happiness + AnimalDataUtilities.HappinessConfig()[AnimalTypes.Lizard]);
        }
        public override void Feed()
        {
            Hunger = (Hunger - AnimalDataUtilities.FeedConfig()[AnimalTypes.Lizard]);
        }
    }
}