using FluentValidation;

namespace WebAPI.Operations.BookOperations.Commands.Create
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(p => p.createBookModel.Name).MinimumLength(1);
            RuleFor(p => p.createBookModel.GenreId).GreaterThan(0);
            RuleFor(p => p.createBookModel.Author).MinimumLength(2);
        }
    }
}
