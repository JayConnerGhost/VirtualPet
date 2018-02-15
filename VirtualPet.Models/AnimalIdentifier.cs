namespace VirtualPet.Models
{
    public class AnimalIdentifier
    {
        public AnimalIdentifier()
        {
        }

        public AnimalIdentifier(string userId, string animalName)
        {
            UserId = userId;
            AnimalName = animalName;
        }

        public string UserId {  set; get; }
        public string AnimalName {  set; get; }
    }
}