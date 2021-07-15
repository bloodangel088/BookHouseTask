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

        [HttpGet("{id}")]
        public async Task<AuthorDTO> Get([FromRoute(Name = "id")] int authorId)
        {
            return await _authorsService.GetById(authorId);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAuthorDTO createAuthorDTO)
        {
            await _authorsService.Add(createAuthorDTO);

            return NoContent();
        }
    }
}
