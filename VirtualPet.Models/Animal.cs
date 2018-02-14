using System;

namespace VirtualPet.Models
{
    public class Animal:IAnimal
    {
        public Animal()
        {
            Hunger = 0;
            Happiness = 0;
        }

        public string Name { get; set; }
        public AnimalTypes Type { get; set; }
        public string Owner { get; set; }
        public int Happiness { get; set; }
        public double Hunger { get; set; }

        public virtual void Pet()
        {
            Happiness++;
        }


        public virtual void Feed()
        {
            Hunger--;
        }

    }
}
