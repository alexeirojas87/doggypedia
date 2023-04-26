namespace DogBreedApp.Shared.DTO
{
    public class DogDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BreedId { get; set; }
        public string BreedName { get; set; }
        public string Sex { get; set; }
        public int MotherId { get; set; }
        public int FatherId { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
