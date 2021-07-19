

namespace BookHouseApp.BuisnessLogic.DTOS.Book
{
    public class CreateBookDTO
    {
        public string Name { get; set; }
        public GenreDTO Genre { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int AuthorId { get; set; }
    }
}
