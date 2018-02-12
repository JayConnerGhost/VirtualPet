namespace VirtualPet.Models
{
    public class Cat :Animal, IAnimal
    {
        public override void Pet()
        {
            throw new System.NotImplementedException();
        }
    }
}