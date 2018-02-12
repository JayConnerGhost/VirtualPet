namespace VirtualPet.Models
{
    public class Cat :Animal, IAnimal
    {
        public override void Pet()
        {
            Happiness = (Happiness + 2);
        }
    }
}