using AutoMapper;
using BookHouseApp.BuisnessLogic.DTOS.Author;
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
        private readonly IMapper _mapper;

        public AuthorService(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public async Task Add(CreateAuthorDTO createAuthorDTO)
        {
            Author author = _mapper.Map<CreateAuthorDTO, Author>(createAuthorDTO);

            await _databaseContext.Authors.AddAsync(author);
            await _databaseContext.SaveChangesAsync();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthorDTO[]> GetAll()
        {
            Author[] authors = await _databaseContext.Authors
                .AsNoTracking()
                .Include(author => author.Books)
                .ToArrayAsync();

            return _mapper.Map<Author[], AuthorDTO[]>(authors);
        }

        public async Task<AuthorDTO> GetById(int id)
        {
            Author author = await _databaseContext.Authors
                .AsNoTracking()
                .Include(author => author.Books)
                .SingleOrDefaultAsync(author => author.Id == id);

            return _mapper.Map<Author, AuthorDTO>(author);
        }

        public Task Update(int id, UpdateAuthorDTO updateAuthorDTO)
        {
            throw new NotImplementedException();
        }
    }
}
