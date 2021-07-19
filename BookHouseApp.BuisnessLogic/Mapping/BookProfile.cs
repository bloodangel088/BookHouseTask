using AutoMapper;
using BookHouseApp.BuisnessLogic.DTOS;
using BookHouseApp.BuisnessLogic.DTOS.Book;
using BookHouseApp.DataAccess.Entities;

namespace BookHouseApp.BuisnessLogic.Mapping
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDTO>().ForMember(DTO => DTO.Author, rule => rule.MapFrom(authorBook => authorBook.Author.AuthorName));
            CreateMap<Genre, GenreDTO>();
            CreateMap<CreateBookDTO, Book>();
            CreateMap<BookDTO, Book>()
                .ForMember(book => book.Id, rule => rule.Ignore());

            CreateMap<UpdateBookDTO, BookDTO>();
            CreateMap<BookDTO, UpdateBookDTO>();

        }
    }
}
