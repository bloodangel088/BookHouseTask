using BookHouseApp.BuisnessLogic.DTOS.Author;
using BookHouseApp.BuisnessLogic.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookHouse.API.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsService _authorsService;

        public AuthorsController(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpGet]
        public async Task<AuthorDTO[]> GetAll()
        {
            return await _authorsService.GetAll();
        }
    }
}
