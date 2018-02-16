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
            
            base.Pet();
        }

        public override void Feed()
        {
            Hunger = (Hunger - AnimalDataUtilities.FeedConfig()[AnimalTypes.Dog]);
            base.Feed();
        }
    }
}