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
        public double Happiness { get; set; }
        public double Hunger { get; set; }
        public DateTime? LastFed { get; set; }
        public DateTime? LastPetted { get; set; }


        public virtual void Pet()
        {
            LastPetted = DateTime.Now;
        }


        public virtual void Feed()
        {
            LastFed = DateTime.Now;
        }

    }
}
