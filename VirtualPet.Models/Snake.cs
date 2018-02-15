namespace VirtualPet.Models
{
    public class Snake : Animal, IAnimal
    {
        public Snake()
        {
            Type = AnimalTypes.Snake;
        }

        public override void Pet()
        {
            Happiness = (Happiness + AnimalDataUtilities.HappinessConfig()[AnimalTypes.Snake]);
            base.Pet();
        }

        public override void Feed()
        {
            Hunger = (Hunger - AnimalDataUtilities.FeedConfig()[AnimalTypes.Snake]);
            base.Feed();
        }
    }
}