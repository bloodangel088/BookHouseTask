namespace BookHouseApp.BuisnessLogic.DTOS.Book
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public GenreDTO Genre { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int AuthorId { get; set; }
        public string Author { get; set; }
    }
}
