using BookHouseApp.BuisnessLogic.DTOS.Book;
using System.Threading.Tasks;

namespace BookHouseApp.BuisnessLogic.Services.Contracts
{
    public interface IBookService
    {
        Task<BookDTO[]> GetAll();
        Task<BookDTO> GetById(int id);
        Task Add(CreateBookDTO createBookDTO);
        Task Update(int id, BookDTO updateBookDTO);
        Task DeleteById(int id);
    }
}
