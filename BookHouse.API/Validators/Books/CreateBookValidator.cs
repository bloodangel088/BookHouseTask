using BookHouseApp.BuisnessLogic.DTOS.Book;
using FluentValidation;

namespace BookHouse.API.Validators.Books
{
    public class CreateBookValidator : AbstractValidator<CreateBookDTO>
    {
        public CreateBookValidator()
        {
            RuleFor(createBook => createBook.Description)
                .NotEmpty()
                .MaximumLength(1024);

            RuleFor(createBook => createBook.Name)
                .NotEmpty()
                .MaximumLength(128);

            RuleFor(createBook => createBook.Genre)
                .NotEmpty();

            RuleFor(createBook => createBook.Year)
                .NotEmpty();

            RuleFor(createBook => createBook.AuthorId)
                .NotEmpty();
        }
    }
}
