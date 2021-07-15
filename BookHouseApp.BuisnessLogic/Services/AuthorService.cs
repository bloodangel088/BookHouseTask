using BookHouseApp.BuisnessLogic.DTOS.Author;
using BookHouseApp.BuisnessLogic.Mapping;
using BookHouseApp.BuisnessLogic.Services.Contracts;
using BookHouseApp.DataAccess.Database;
using BookHouseApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BookHouseApp.BuisnessLogic.Services
{
    public class AuthorService : IAuthorsService
    {
        private readonly DatabaseContext _databaseContext;

        public AuthorService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Task Add(CreateAuthorDTO createAuthorDTO)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthorDTO[]> GetAll()
        {
            Author[] authors = await _databaseContext.Authors
                .AsNoTracking()
                .ToArrayAsync();

            return Mapper.MapFromAuthorToDtos(authors);
        }

        public async Task<AuthorDTO> GetById(int id)
        {
            Author author = await _databaseContext.Authors
                .AsNoTracking()
                .SingleOrDefaultAsync(author => author.Id == id);

            return Mapper.MapFromAuthorToDto(author);
        }

        public Task Update(int id, UpdateAuthorDTO updateAuthorDTO)
        {
            throw new NotImplementedException();
        }
    }
}
