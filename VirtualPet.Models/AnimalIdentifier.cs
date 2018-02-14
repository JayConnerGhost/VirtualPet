namespace VirtualPet.Models
{
    public class AnimalIdentifier
    {
        public AnimalIdentifier(string userId, string animalName)
        {
            UserId = userId;
            AnimalName = animalName;
        }

        public string UserId { private set; get; }
        public string AnimalName { private set; get; }
    }
}