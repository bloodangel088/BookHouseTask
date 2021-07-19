using BookHouseApp.BuisnessLogic.DTOS.Author;
using FluentValidation;

namespace BookHouse.API.Validators.Authors
{
    public class CreateAuthorValidator : AbstractValidator<CreateAuthorDTO>
    {
        public CreateAuthorValidator()
        {
            RuleFor(createAuthor => createAuthor.AuthorName)
                .NotEmpty()
                .MaximumLength(128);

            RuleFor(createAuthor => createAuthor.Country)
                .NotEmpty()
                .MaximumLength(128);

            RuleFor(createAuthor => createAuthor.DateOfBirth)
                .NotEmpty();
        }
    }
}
