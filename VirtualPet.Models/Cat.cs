namespace VirtualPet.Models
{
    public class Cat :Animal, IAnimal
    {
        public override void Pet()
        {
            Happiness = (Happiness + AnimalDataUtilities.HappinessConfig()[AnimalTypes.Cat]);
        }
    }

    public class Dog :Animal, IAnimal
    {
        public override void Pet()
        {
            Happiness = (Happiness + AnimalDataUtilities.HappinessConfig()[AnimalTypes.Dog]);
        }
    }

    public class Snake : Animal, IAnimal
    {
        public override void Pet()
        {
            Happiness = (Happiness + AnimalDataUtilities.HappinessConfig()[AnimalTypes.Snake]);
        }
    }

    public class Fish : Animal, IAnimal
    {
        public override void Pet()
        {
            Happiness = (Happiness + AnimalDataUtilities.HappinessConfig()[AnimalTypes.Fish]);
        }
    }

    public class Lizard : Animal, IAnimal
    {
        public override void Pet()
        {
            Happiness = (Happiness + AnimalDataUtilities.HappinessConfig()[AnimalTypes.Lizard]);
        }
    }
}