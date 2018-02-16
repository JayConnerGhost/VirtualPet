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
            
            base.Pet();
        }

        public override void Feed()
        {
            Hunger = (Hunger - AnimalDataUtilities.FeedConfig()[AnimalTypes.Cat]);
            base.Feed();
        }
    }
}