namespace VirtualPet.Models
{
    public interface IAnimal
    {
         string Name { get; set; }
         AnimalTypes Type { get; }
         string Owner { get; set; }
         int Happiness { get; }
         void Pet();
    }
}