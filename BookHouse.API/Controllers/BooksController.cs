using AutoMapper;
using BookHouseApp.BuisnessLogic.DTOS.Book;
using BookHouseApp.BuisnessLogic.Services.Contracts;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookHouse.API.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateBookDTO> _updateBookValidator;

        public BooksController(IBookService bookService, IMapper mapper, IValidator<UpdateBookDTO> updateBookValidator)
        {
            _bookService = bookService;
            _mapper = mapper;
            _updateBookValidator = updateBookValidator;
        }

        [HttpGet]
        public async Task<BookDTO[]> GetAll()
        {
            return await _bookService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<BookDTO> Get([FromRoute(Name = "id")] int bookId)
        {
            return await _bookService.GetById(bookId);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookDTO createBookDTO)
        {
            await _bookService.Add(createBookDTO);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch([FromRoute] int id, [FromBody] JsonPatchDocument<UpdateBookDTO> patchDocument)
        {
            BookDTO bookDTO = await _bookService.GetById(id);
            UpdateBookDTO updateBookDTO = _mapper.Map<BookDTO, UpdateBookDTO>(bookDTO);
            patchDocument.ApplyTo(updateBookDTO);
            _updateBookValidator.ValidateAndThrow(updateBookDTO);
            BookDTO patchedBookDTO = _mapper.Map<UpdateBookDTO, BookDTO>(updateBookDTO);

            await _bookService.Update(id, patchedBookDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _bookService.DeleteById(id);

            return NoContent();
        }
    }
}
