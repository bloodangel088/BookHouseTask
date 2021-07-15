using AutoMapper;
using BookHouseApp.BuisnessLogic.DTOS;
using BookHouseApp.BuisnessLogic.DTOS.Author;
using BookHouseApp.DataAccess.Entities;

namespace BookHouseApp.BuisnessLogic.Mapping
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDTO>();
            CreateMap<CreateAuthorDTO, Author>();
        }
    }
}
