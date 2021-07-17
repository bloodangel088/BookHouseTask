using AutoMapper;
using BookHouseApp.BuisnessLogic.DTOS.Author;
using BookHouseApp.BuisnessLogic.Services.Contracts;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookHouse.API.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsService _authorsService;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorsService authorsService, IMapper mapper)
        {
            _authorsService = authorsService;
            _mapper = mapper;
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

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch([FromRoute] int id, [FromBody] JsonPatchDocument<UpdateAuthorDTO> patchDocument)
        {
            AuthorDTO authorDTO = await _authorsService.GetById(id);

            UpdateAuthorDTO updateAuthorDTO = _mapper.Map<AuthorDTO, UpdateAuthorDTO>(authorDTO);

            patchDocument.ApplyTo(updateAuthorDTO);

            AuthorDTO patchedAuthorDTO = _mapper.Map<UpdateAuthorDTO, AuthorDTO>(updateAuthorDTO);

            await _authorsService.Update(id, patchedAuthorDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _authorsService.DeleteById(id);

            return NoContent();
        }
    }
}
