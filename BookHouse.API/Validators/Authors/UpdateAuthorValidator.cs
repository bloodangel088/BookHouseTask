using BookHouseApp.BuisnessLogic.DTOS.Author;
using FluentValidation;

namespace BookHouse.API.Validators.Authors
{
    public class UpdateAuthorValidator : AbstractValidator<UpdateAuthorDTO>
    {
        public UpdateAuthorValidator()
        {
            RuleFor(updateAuthor => updateAuthor.AuthorName)
                .NotEmpty()
                .MaximumLength(128);

            RuleFor(updateAuthor => updateAuthor.Country)
                .NotEmpty()
                .MaximumLength(128);

            RuleFor(updateAuthor => updateAuthor.DateOfBirth)
                .NotEmpty();
        }
    }
}
