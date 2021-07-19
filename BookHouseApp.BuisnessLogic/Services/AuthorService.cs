using AutoMapper;
using BookHouseApp.BuisnessLogic.DTOS.Author;
using BookHouseApp.BuisnessLogic.Services.Contracts;
using BookHouseApp.DataAccess.Database;
using BookHouseApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task DeleteById(int id)
        {
            Author authorToDelete = await _databaseContext.Authors.SingleOrDefaultAsync(author => author.Id == id)
                ?? throw new KeyNotFoundException($"Author with id '{id}' does not exists.");

            _databaseContext.Authors.Remove(authorToDelete);
            await _databaseContext.SaveChangesAsync();
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
                .SingleOrDefaultAsync(author => author.Id == id)
                ?? throw new KeyNotFoundException($"Author with id '{id}' does not exists.");

            return _mapper.Map<Author, AuthorDTO>(author);
        }

        public async Task Update(int id, AuthorDTO updateAuthorDTO)
        {
            Author existingAuthor = await _databaseContext.Authors.SingleOrDefaultAsync(author => author.Id == id)
                ?? throw new KeyNotFoundException($"Author with id '{id}' does not exists.");

            _mapper.Map(updateAuthorDTO, existingAuthor);

            _databaseContext.Update(existingAuthor);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
