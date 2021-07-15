using BookHouseApp.BuisnessLogic.DTOS;
using BookHouseApp.BuisnessLogic.DTOS.Author;
using BookHouseApp.BuisnessLogic.DTOS.Book;
using BookHouseApp.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace BookHouseApp.BuisnessLogic.Mapping
{
    public static class Mapper
    {
        public static AuthorDTO[] MapFromAuthorToDtos(Author[] authors)
        {
            List<AuthorDTO> dtos = new List<AuthorDTO>();

            foreach (Author author in authors)
            {
                dtos.Add(MapFromAuthorToDto(author));
            }
            return dtos.ToArray();
        }
        public static AuthorDTO MapFromAuthorToDto(Author author, bool mapCollections = false)
        {
            return new AuthorDTO
            {
                Id = author.Id,
                Country = author.Country,
                DateOfBirth = author.DateOfBirth,
                AuthorName = author.AuthorName,
                Books = mapCollections
                    ? MapFromBookToDtos(author.Books)
                    : null
            };
        }

        public static BookDTO[] MapFromBookToDtos(IReadOnlyCollection<Book> books)
        {
            var dtos = new List<BookDTO>();
            foreach (Book book in books)
            {
                dtos.Add(MapFromBookToDto(book));
            }

            return dtos.ToArray();
        }

        public static BookDTO MapFromBookToDto(Book book)
        {
            return new BookDTO
            {
                AuthorId = book.AuthorId,
                Description = book.Description,
                Genre = MapFromGenreToDto(book.Genre),
                Id = book.Id,
                Year = book.Year,
                Name = book.Name,
                Author = MapFromAuthorToDto(book.Author, false),
            };
        }

        private static GenreDTO MapFromGenreToDto(Genre genre)
        {
            return Enum.Parse<GenreDTO>(genre.ToString());
        }
    }
}
