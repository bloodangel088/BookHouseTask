using BookHouseApp.BuisnessLogic.DTOS.Book;
using FluentValidation;

namespace BookHouse.API.Validators.Books
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookDTO>
    {
        public UpdateBookValidator()
        {
            RuleFor(updateBook => updateBook.Description)
                .NotEmpty()
                .MaximumLength(1024);

            RuleFor(updateBook => updateBook.Name)
                .NotEmpty()
                .MaximumLength(128);

            RuleFor(updateBook => updateBook.Genre)
                .NotEmpty();

            RuleFor(updateBook => updateBook.Year)
                .NotEmpty();

            //RuleFor(updateBook => updateBook.AuthorId)
            //    .NotEmpty();
        }
    }
}
