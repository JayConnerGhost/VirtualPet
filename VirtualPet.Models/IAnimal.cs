using System;

namespace VirtualPet.Models
{
    public interface IAnimal
    {
         string Name { get; set; }
         AnimalTypes Type { get; }
         string Owner { get; set; }
         double Happiness { get; set; }
         double Hunger { get; set; }
         DateTime? LastFed { get; set; }
         DateTime? LastPetted { get; set; }
         void Pet();
         void Feed();
    }
}