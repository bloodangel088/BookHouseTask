using AutoMapper;
using BookHouseApp.BuisnessLogic.DTOS.Author;
using BookHouseApp.DataAccess.Entities;

namespace BookHouseApp.BuisnessLogic.Mapping
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDTO>();
            CreateMap<AuthorDTO, Author>()
                .ForMember(author => author.Id, rule => rule.Ignore());

            CreateMap<CreateAuthorDTO, Author>();

            CreateMap<UpdateAuthorDTO, AuthorDTO>();
            CreateMap<AuthorDTO, UpdateAuthorDTO>();
        }
    }
}
