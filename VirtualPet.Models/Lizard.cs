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
          
            base.Pet();
        }
        public override void Feed()
        {
            Hunger = (Hunger - AnimalDataUtilities.FeedConfig()[AnimalTypes.Lizard]);
            base.Feed();
        }
    }
}