using BookHouseApp.BuisnessLogic.DTOS.Book;
using System;

namespace BookHouseApp.BuisnessLogic.DTOS.Author
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        public BookDTO[] Books { get; set; }
    }
}
