using System.ComponentModel.DataAnnotations;

namespace BookHouseApp.DataAccess.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [MaxLength(128)]
        public string Name { get; set; }
        public Genre Genre { get; set; }
        [MaxLength(1024)]
        public string Description { get; set; }
        public int Year { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }

    }
}
