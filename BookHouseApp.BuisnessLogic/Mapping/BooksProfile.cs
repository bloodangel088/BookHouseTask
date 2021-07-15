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
                .ForMember(dto => dto.Author, expressions => expressions.MapFrom(author => author.Name));

            CreateMap<Genre, GenreDTO>();
        }
    }
}
