using AutoMapper;
using BookHouseApp.BuisnessLogic.DTOS.Book;
using BookHouseApp.BuisnessLogic.Services.Contracts;
using BookHouseApp.DataAccess.Database;
using BookHouseApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookHouseApp.BuisnessLogic.Services
{
    public class BookService : IBookService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public BookService(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public async Task Add(CreateBookDTO createBookDTO)
        {
            Book book = _mapper.Map<CreateBookDTO, Book>(createBookDTO);
            await _databaseContext.Books.AddAsync(book);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            Book bookToDelete = await _databaseContext.Books.SingleOrDefaultAsync(book => book.Id == id)
                ?? throw new KeyNotFoundException($"Book with id '{id}' does not exists.");

            _databaseContext.Books.Remove(bookToDelete);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<BookDTO[]> GetAll()
        {
            Book[] books = await _databaseContext.Books
                .AsNoTracking()
                .Include(books => books.Author)
                .ToArrayAsync();

            return _mapper.Map<Book[], BookDTO[]>(books);
        }

        public async Task<BookDTO> GetById(int id)
        {
            Book book = await _databaseContext.Books
                .AsNoTracking()
                .Include(book => book.Author)
                .SingleOrDefaultAsync(book => book.Id == id)
                ?? throw new KeyNotFoundException($"Book with id '{id}' does not exists.");

            return _mapper.Map<Book, BookDTO>(book);
        }

        public async Task Update(int id, BookDTO updateBookDTO)
        {
            Book existingBook = await _databaseContext.Books.SingleOrDefaultAsync(book => book.Id == id)
                ?? throw new KeyNotFoundException($"Book with id '{id}' does not exists.");

            _mapper.Map(updateBookDTO, existingBook);

            _databaseContext.Update(existingBook);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
