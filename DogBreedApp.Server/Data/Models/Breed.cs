namespace DogBreedApp.Server.Data.Models
{
    public class Breed
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Relación uno a muchos con Dog
        public virtual ICollection<Dog> Dogs { get; set; }
    }
}
