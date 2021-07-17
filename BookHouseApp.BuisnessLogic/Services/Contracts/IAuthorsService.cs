using BookHouseApp.BuisnessLogic.DTOS.Author;
using System.Threading.Tasks;

namespace BookHouseApp.BuisnessLogic.Services.Contracts
{
    public interface IAuthorsService
    {
        Task<AuthorDTO[]> GetAll();
        Task<AuthorDTO> GetById(int id);
        Task Add(CreateAuthorDTO createAuthorDTO);
        Task Update(int id, AuthorDTO updateAuthorDTO);
        Task DeleteById(int id);
    }
}
