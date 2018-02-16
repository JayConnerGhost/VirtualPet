using System;
using System.Threading.Tasks;
using System.Timers;


namespace VirtualPet.Models
{
    public class Animal:IAnimal
    {
        public Animal()
        {
            Hunger = 0;
            Happiness = 0;
            Sad();
            Hungry();
        }

        public string Name { get; set; }
        public AnimalTypes Type { get; set; }
        public string Owner { get; set; }
        public double Happiness { get; set; }
        public double Hunger { get; set; }
        public DateTime? LastFed { get; set; }
        public DateTime? LastPetted { get; set; }

        private void Sad()
        {
            var minuete = 60000;
            var interval = (AnimalDataUtilities.HappinessConfig()[Type] * minuete);
            var timer = new Timer(interval) {AutoReset = true};
            timer.Elapsed += async (sender, e) => await decreaseHappiness();
            timer.Start();

        }

        private void Hungry()
        {
            var minuete = 60000;
            var interval = (AnimalDataUtilities.HappinessConfig()[Type] * minuete);
            var timer = new Timer(interval) { AutoReset = true };
            timer.Elapsed += async (sender, e) => await increaseHunger();
            timer.Start();
        }

        private Task increaseHunger()
        {
            //NOTE: [Developer, Architech] this works with an in memory repo and models the concept of an always online server
            //however - logic would have to be in place to save transition values on this event being triggered 
            //values also can be acalculated back from the LastFeed value -> this has been included mainly to support this note. 
            //the approach below satisfies the brief and is fine for a demo, but in production we would need to modify this approach.
            Hunger = Hunger + (AnimalDataUtilities.FeedConfig()[Type] / 2);
            return Task.CompletedTask;
        }

        private Task decreaseHappiness()
        {
            //NOTE: [Developer, Architech] this works with an in memory repo and models the concept of an always online server
            //however - logic would have to be in place to save transition values on this event being triggered 
            //values also can be acalculated back from the LastPetted value -> this has been included mainly to support this note. 
            //the approach below satisfies the brief and is fine for a demo, but in production we would need to modify this approach.

            Happiness = Happiness - (AnimalDataUtilities.HappinessConfig()[Type]/2);
            return Task.CompletedTask;
        }

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
