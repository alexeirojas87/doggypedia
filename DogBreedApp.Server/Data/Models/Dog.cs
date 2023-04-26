using System.ComponentModel.DataAnnotations.Schema;

namespace DogBreedApp.Server.Data.Models
{
    public class Dog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateTime? BirthDate { get; set; }

        // Relación muchos a uno con Breed
        public int BreedId { get; set; }
        public virtual Breed Breed { get; set; }

        // Relación recursiva con Dog (progenitores)
        public int? FatherId { get; set; }
        public virtual Dog Father { get; set; }

        public int? MotherId { get; set; }
        public virtual Dog Mother { get; set; }
    }
}
