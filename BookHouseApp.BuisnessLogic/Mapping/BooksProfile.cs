using AutoMapper;
using BookHouseApp.BuisnessLogic.DTOS;
using BookHouseApp.BuisnessLogic.DTOS.Book;
using BookHouseApp.DataAccess.Entities;

namespace BookHouseApp.BuisnessLogic.Mapping
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            CreateMap<Book, BookDTO>()
                .ForMember(dto => dto.Author, rule => rule.MapFrom(book => book.Author.AuthorName))
                .ForMember(dto => dto.Title, rule => rule.MapFrom(book => book.Name));

            CreateMap<Genre, GenreDTO>();
        }
    }
}
